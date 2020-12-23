using System;
using DatePicker.Domain.UnitTests.Helpers;
using Shouldly;
using Xunit;

namespace DatePicker.Domain.UnitTests
{
    public class EventTests
    {
        [Fact]
        public void Event_can_be_created_for_user_with_event_name_and_date()
        {
            var user = "testuser";
            var dateTime = DateTime.Now + TimeSpan.FromDays(1);
            var name = "testname";

            var sut = new Event(user, name, dateTime);

            sut.User.ShouldBe(user);
            sut.ProposedDateTimes.ShouldBe(new[] { dateTime });
            sut.Name.ShouldBe(name);
        }

        [Theory]
        [ClassData(typeof(InvalidNamesData))]
        public void Event_cannot_be_created_with_invalid_username(string invalidUserName)
        {
            var dateTime = DateTime.Now + TimeSpan.FromDays(1);
            var name = "testname";

            Should.Throw<ArgumentException>(() => new Event(invalidUserName, name, dateTime));
        }

        [Theory]
        [ClassData(typeof(InvalidNamesData))]
        public void Event_cannot_be_created_with_invalid_event_name(string invalidName)
        {
            var user = "testuser";
            var dateTime = DateTime.Now + TimeSpan.FromDays(1);

            Should.Throw<ArgumentException>(() => new Event(user, invalidName, dateTime));
        }

        [Fact]
        public void Event_cannot_be_created_with_past_date()
        {
            var user = "testuser";
            var dateTimeInThePast = DateTime.Now - TimeSpan.FromDays(1);
            var name = "testname";

            Should.Throw<ArgumentException>(() => new Event(user, name, dateTimeInThePast));
        }

        [Fact]
        public void User_can_propose_date_and_time_for_an_existing_event()
        {
            var user = "testuser";
            var initialDateTime = DateTime.Now + TimeSpan.FromDays(1);
            var name = "testname";
            var sut = new Event(user, name, initialDateTime);
            var dateTimeToPropose = DateTime.Now + TimeSpan.FromDays(2);

            sut.AddProposedDateAndTime(dateTimeToPropose);

            sut.ProposedDateTimes.ShouldBe(new[] { initialDateTime, dateTimeToPropose }, ignoreOrder: true);
        }

        [Fact]
        public void User_cannot_propose_past_date_and_time()
        {
            var user = "testuser";
            var name = "testname";
            var initialDateTime = DateTime.Now + TimeSpan.FromDays(1);
            var dateTimeToProposeInThePast = DateTime.Now - TimeSpan.FromDays(1);
            var sut = new Event(user, name, initialDateTime);

            Should.Throw<ArgumentException>(() =>
                sut.AddProposedDateAndTime(dateTimeToProposeInThePast));
        }
    }
}