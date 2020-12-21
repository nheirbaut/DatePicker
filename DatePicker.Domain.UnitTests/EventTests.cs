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
            var dateTime = DateTime.Now;
            var name = "testname";

            var sut = new Event(user, name, dateTime);

            sut.User.ShouldBe(user);
            sut.DateTime.ShouldBe(dateTime);
            sut.Name.ShouldBe(name);
        }

        [Theory]
        [ClassData(typeof(InvalidNamesData))]
        public void Event_cannot_be_created_with_invalid_username(string invalidUserName)
        {
            var dateTime = DateTime.Now;
            var name = "testname";

            Should.Throw<ArgumentException>(() => new Event(invalidUserName, name, dateTime));
        }

        [Theory]
        [ClassData(typeof(InvalidNamesData))]
        public void Event_cannot_be_created_with_invalid_event_name(string invalidName)
        {
            var user = "testuser";
            var dateTime = DateTime.Now;

            Should.Throw<ArgumentException>(() => new Event(user, invalidName, dateTime));
        }
    }
}