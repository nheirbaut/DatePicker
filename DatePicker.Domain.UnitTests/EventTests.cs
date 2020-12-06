using System;
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
    }
}