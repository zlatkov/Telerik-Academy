namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class EventsManagerFast : IEventsManager
    {
        private readonly MultiDictionary<string, Event> eventsByTitle;
        private readonly OrderedMultiDictionary<DateTime, Event> eventsByDate;

        public EventsManagerFast()
        {
            this.eventsByTitle = new MultiDictionary<string, Event>(true);
            this.eventsByDate = new OrderedMultiDictionary<DateTime, Event>(true);
        }

        public void AddEvent(Event newEvent)
        {
            string eventTitleLowerCase = newEvent.Title.ToLowerInvariant();
            this.eventsByTitle.Add(eventTitleLowerCase, newEvent);
            this.eventsByDate.Add(newEvent.Date, newEvent);
        }

        public int DeleteEventsByTitle(string eventTitle)
        {
            string eventTitleLowerCase = eventTitle.ToLowerInvariant();
            var eventsToDelete = this.eventsByTitle[eventTitleLowerCase];
            int eventsDeletedCount = eventsToDelete.Count;

            if (eventsDeletedCount == 0)
            {
                return 0;
            }

            foreach (var newEvent in eventsToDelete)
            {
                this.eventsByDate.Remove(newEvent.Date, newEvent);
            }

            this.eventsByTitle.Remove(eventTitleLowerCase);

            return eventsDeletedCount;
        }

        public IEnumerable<Event> ListEvents(DateTime staringDate, int numberOfEventsToList)
        { 
            var allEventsAfterDate =
                from newEvent in this.eventsByDate.RangeFrom(staringDate, true).Values
                select newEvent;
            
            var eventsToList = allEventsAfterDate.Take(numberOfEventsToList);
            return eventsToList;
        }
    }
}
