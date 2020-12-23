using System;
using System.Collections.Generic;

namespace DatePicker.Domain
{
    public class Event
    {
        private ICollection<DateTime> _proposedDateTimes;

        public string User { get; }
        public string Name { get; }
        public IEnumerable<DateTime> ProposedDateTimes => _proposedDateTimes;

        public Event(string user, string name, DateTime dateTime)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new ArgumentException("The user name cannot be only whitespace or null", nameof(user));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The event name cannot be only whitespace or null", nameof(name));

            ValidateProposedDateAndTime(dateTime);

            User = user;
            Name = name;
            _proposedDateTimes = new List<DateTime> { dateTime };
        }

        public void AddProposedDateAndTime(DateTime proposedDateTime)
        {
            ValidateProposedDateAndTime(proposedDateTime);

            _proposedDateTimes.Add(proposedDateTime);
        }

        private static void ValidateProposedDateAndTime(DateTime proposedDateTime)
        {
            if (proposedDateTime < DateTime.Now)
                throw new ArgumentException($"Cannot create an event with a date in the past: {proposedDateTime}", nameof(proposedDateTime));
        }
    }
}