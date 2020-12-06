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
            User = user;
            Name = name;
            DateTime = dateTime;
        }
    }
}