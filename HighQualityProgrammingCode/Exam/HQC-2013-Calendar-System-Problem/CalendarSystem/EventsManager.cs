namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EventsManager : IEventsManager
    {
        private readonly List<Event> events;

        public EventsManager()
        {
            this.events = new List<Event>();
        }

        public void AddEvent(Event newEvent)
        {
            this.events.Add(newEvent);
        }

        public int DeleteEventsByTitle(string title)
        {
            return this.events.RemoveAll(
                currentEvent => currentEvent.Title.ToLowerInvariant() == title.ToLowerInvariant());
        }

        public IEnumerable<Event> ListEvents(DateTime date, int numberOfEventsToList)
        {
            return (from currentEvent in this.events
                    where currentEvent.Date >= date
                    orderby currentEvent
                    select currentEvent).Take(numberOfEventsToList);
        }
    }
}