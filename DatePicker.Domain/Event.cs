using System;

namespace DatePicker.Domain
{
    public class Event
    {
        public string User { get; }
        public string Name { get; }
        public DateTime DateTime { get; }

        public Event(string user, string name, DateTime dateTime)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new ArgumentException("The user name cannot be only whitespace or null", nameof(user));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The event name cannot be only whitespace or null", nameof(name));

            if (dateTime < DateTime.Now)
                throw new ArgumentException($"Cannot create an event with a date in the past: {dateTime}", nameof(dateTime));

            User = user;
            Name = name;
            DateTime = dateTime;
        }
    }
}