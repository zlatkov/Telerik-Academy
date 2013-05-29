namespace CalendarSystemTests
{
    using System;
    using System.Collections.Generic;
    using CalendarSystem;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EventsManagerFastTests
    {
        private int CountEvents(IEnumerable<Event> events)
        {
            int eventsCount = 0;
            foreach (var item in events)
            {
                eventsCount++;
            }

            return eventsCount;
        }

        [TestMethod]
        public void TestDeleteEventsByTitle_WhenSingleEventIsAddedAndMatches()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(new Event(DateTime.Now, "Title"));

            int numberOfDeletedEvents = eventsManager.DeleteEventsByTitle("Title");

            Assert.AreEqual(1, numberOfDeletedEvents);
        }

        [TestMethod]
        public void TestDeleteEventsByTitle_WhenSingleEventIsAddedAndDoesNotMatch()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(new Event(DateTime.Now, "Title"));

            int numberOfDeletedEvents = eventsManager.DeleteEventsByTitle("OtherTitle");

            Assert.AreEqual(0, numberOfDeletedEvents);
        }

        [TestMethod]
        public void TestDeleteEventsByTitle_WhenMultipleEevntsAreAddedAndAllMatch()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            int totalNumberOfEvents = 10;
            for (int i = 0; i < totalNumberOfEvents; i++)
            {
                eventsManager.AddEvent(new Event(DateTime.Now, "Title"));
            }

            int numberOfDeletedEvents = eventsManager.DeleteEventsByTitle("Title");

            Assert.AreEqual(totalNumberOfEvents, numberOfDeletedEvents);
        }

        [TestMethod]
        public void TestDeleteEventsByTitle_WhenMultipleEventsAreAddedAndSomeOfThemMatch()
        {

            EventsManagerFast eventsManager = new EventsManagerFast();
            int totalNumberOfEvents = 10;
            for (int i = 0; i < totalNumberOfEvents; i++)
            {
                string titleIndex = (i % 2).ToString();
                eventsManager.AddEvent(new Event(DateTime.Now, "Title" + titleIndex));
            }

            int numberOfDeletedEvents = eventsManager.DeleteEventsByTitle("Title0");

            Assert.AreEqual(totalNumberOfEvents / 2, numberOfDeletedEvents);
        }

        [TestMethod]
        public void TestDeleteEventsByTitle_WhenMultipleEventsAreAddedAndNoneOfThemMatch()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            int totalNumberOfEvents = 10;
            for (int i = 0; i < totalNumberOfEvents; i++)
            {
                eventsManager.AddEvent(new Event(DateTime.Now, "Title"));
            }

            int numberOfDeletedEvents = eventsManager.DeleteEventsByTitle("Title1");

            Assert.AreEqual(0, numberOfDeletedEvents);
        }

        [TestMethod]
        public void TestDeleteEventsByTitle_WhenMultipleEventsAreAddedAndOnlyOneMatches()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            for (int i = 0; i < 10; i++)
            {
                eventsManager.AddEvent(new Event(DateTime.Now, "Title"));
            }

            eventsManager.AddEvent(new Event(DateTime.Now, "Title1"));
            int numberOfDeletedEvents = eventsManager.DeleteEventsByTitle("Title1");

            Assert.AreEqual(1, numberOfDeletedEvents);
        }

        [TestMethod]
        public void TestDeleteEventsByTitle_WhenNoEevntsAreAdded()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            int numberOfDeletedEvents = eventsManager.DeleteEventsByTitle("Title");

            Assert.AreEqual(0, numberOfDeletedEvents);
        }

        [TestMethod]
        public void TestListEvents_WhenSingleEventIsAddedAndItIsAfterTheStartingDate()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime yesterday = DateTime.Now.AddDays(-1);
            eventsManager.AddEvent(new Event(DateTime.Now, "Title"));

            IEnumerable<Event> events = eventsManager.ListEvents(yesterday, 10);
            int listedEventsCount = this.CountEvents(events);

            Assert.AreEqual(1, listedEventsCount);
        }

        [TestMethod]
        public void TestListEvents_WhenSingleEventIsAddedAndItIsBeforeTheStartingDate()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime yesterday = DateTime.Now.AddDays(-1);
            eventsManager.AddEvent(new Event(yesterday, "Title"));

            IEnumerable<Event> events = eventsManager.ListEvents(DateTime.Today, 10);
            int listedEventsCount = this.CountEvents(events);

            Assert.AreEqual(0, listedEventsCount);
        }

        [TestMethod]
        public void TestListEvents_WhenSingleEventIsAddedAndItIsAfterTheStartingDate_TheNumberOfDatesToListIsZero()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime yesterday = DateTime.Now.AddDays(-1);
            eventsManager.AddEvent(new Event(DateTime.Now, "Title"));

            IEnumerable<Event> events = eventsManager.ListEvents(yesterday, 0);
            int listedEventsCount = this.CountEvents(events);

            Assert.AreEqual(0, listedEventsCount);
        }

        [TestMethod]
        public void TestListEvents_WhenNoneEventsAreAdded()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            IEnumerable<Event> events = eventsManager.ListEvents(DateTime.Now, 10);
            int listedEventsCount = this.CountEvents(events);

            Assert.AreEqual(0, listedEventsCount);
        }

        [TestMethod]
        public void TestListEvents_WhenMultipleEventsAreAddedAndAllAreAfterTheStartingDate()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime yesterday = DateTime.Now.AddDays(-1);
            int totalNumberOfEvents = 10;
            for (int i = 0; i < totalNumberOfEvents; ++i)
            {
                eventsManager.AddEvent(new Event(DateTime.Now, "Title"));
            }

            IEnumerable<Event> events = eventsManager.ListEvents(yesterday, totalNumberOfEvents);
            int listedEventsCount = this.CountEvents(events);

            Assert.AreEqual(totalNumberOfEvents, listedEventsCount);
        }

        [TestMethod]
        public void TestListEvents_WhenMultipleEventsAreAddedAndAllAreBeforeTheStartingDate()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime yesterday = DateTime.Now.AddDays(-1);
            int totalNumberOfEvents = 10;
            for (int i = 0; i < totalNumberOfEvents; i++)
            {
                eventsManager.AddEvent(new Event(yesterday, "Title"));
            }

            IEnumerable<Event> events = eventsManager.ListEvents(DateTime.Now, totalNumberOfEvents);
            int listedEventsCount = this.CountEvents(events);

            Assert.AreEqual(0, listedEventsCount);
        }

        [TestMethod]
        public void TestListEvents_WhenMultipleEventsAreAddedAndSomeOfThemAreAfterTheStartingDate()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime beforeTwoDays = DateTime.Now.AddDays(-2);
            DateTime yesterday = DateTime.Now.AddDays(-1);
            int totalNumberOfEvents = 20;
            int halfTheNumberOfEvent = totalNumberOfEvents / 2;

            for (int i = 0; i < halfTheNumberOfEvent; i++)
            {
                eventsManager.AddEvent(new Event(DateTime.Now, "Title"));
            }
            for (int i = 0; i < halfTheNumberOfEvent; i++)
            {
                eventsManager.AddEvent(new Event(beforeTwoDays, "Title"));
            }
    

            IEnumerable<Event> events = eventsManager.ListEvents(yesterday, totalNumberOfEvents);
            int listedEventsCount = this.CountEvents(events);

            Assert.AreEqual(halfTheNumberOfEvent, listedEventsCount);
        }

        [TestMethod]
        public void TestListEvents_WhenTheNumberOfEventsToListIsGreaterThanTheMatchingEvents()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime yesterday = DateTime.Now.AddDays(-1);
            int totalNumberOfEvents = 10;
            for (int i = 0; i < totalNumberOfEvents; i++)
            {
                eventsManager.AddEvent(new Event(DateTime.Now, "Title"));
            }

            IEnumerable<Event> events = eventsManager.ListEvents(yesterday, totalNumberOfEvents * 2);
            int listedEventsCount = this.CountEvents(events);

            Assert.AreEqual(totalNumberOfEvents, listedEventsCount);
        }

        [TestMethod]
        public void TestListEvents_WhenTheNumberOfEventsToListIsSmallerThanTheMatchingEvents()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime yesterday = DateTime.Now.AddDays(-1);
            int totalNumberOfEvents = 10;
            for (int i = 0; i < totalNumberOfEvents; i++)
            {
                eventsManager.AddEvent(new Event(DateTime.Now, "Title"));
            }

            IEnumerable<Event> events = eventsManager.ListEvents(yesterday, totalNumberOfEvents - 5);
            int listedEventsCount = this.CountEvents(events);

            Assert.AreEqual(totalNumberOfEvents - 5, listedEventsCount);
        }

        [TestMethod]
        public void TestListEvents_WhenMultipleEventsAreAdded_TheNumberOfEventsToListIsZero()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime yesterday = DateTime.Now.AddDays(-1);
            int totalNumberOfEvents = 10;
            for (int i = 0; i < totalNumberOfEvents; i++)
            {
                eventsManager.AddEvent(new Event(DateTime.Now, "Title"));
            }

            IEnumerable<Event> events = eventsManager.ListEvents(yesterday, 0);
            int listedEventsCount = this.CountEvents(events);

            Assert.AreEqual(0, listedEventsCount);
        }
    }
}
