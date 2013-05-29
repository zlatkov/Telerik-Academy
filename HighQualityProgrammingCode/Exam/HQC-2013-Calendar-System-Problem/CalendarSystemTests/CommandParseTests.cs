using System;
using CalendarSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarSystemTests
{
    [TestClass]
    public class CommandParseTests
    {
        [TestMethod]
        public void TestParse_AddEventWithoutLocation_CommandNameShouldBeInitialized()
        {
            Command command = Command.Parse("AddEvent 2012-01-21T20:00:00 | Title");

            Assert.AreEqual("AddEvent", command.Name);
        }

        [TestMethod]
        public void TestParse_AddEventWithoutLocation_CommandDateShouldBeInitialized()
        {
            Command command = Command.Parse("AddEvent 2012-01-21T20:00:00 | Title");
            string commandDate = command.Parameters[0];

            Assert.AreEqual("2012-01-21T20:00:00", commandDate);
        }

        [TestMethod]
        public void TestParse_AddEventWithoutLocation_CommandTitleShouldBeInitialized()
        {
            Command command = Command.Parse("AddEvent 2012-01-21T20:00:00 | Title");
            string commandTitle = command.Parameters[1];

            Assert.AreEqual("Title", commandTitle);
        }

        [TestMethod]
        public void TestParse_AddEventWithoutLocation_CommandLocationShouldNotBeInitialized()
        {
            Command command = Command.Parse("AddEvent 2012-01-21T20:00:00 | Title");

            Assert.AreEqual(2, command.Parameters.Length);
        }

        [TestMethod]
        public void TestParse_AddEventWithLocation_CommandLocationShouldBeInitialized()
        {
            Command command = Command.Parse("AddEvent 2012-01-21T20:00:00 | Title | Location");
            string commandLocation = command.Parameters[2];

            Assert.AreEqual("Location", commandLocation);
        }

        [TestMethod]
        public void TestParse_DeleteEvents_CommandNameShouldBeInitialized()
        {
            Command command = Command.Parse("DeleteEvents EventTitle");

            Assert.AreEqual("DeleteEvents", command.Name);
        }

        [TestMethod]
        public void TestParse_DeleteEvents_CommandTitleShouldBeInitialized()
        {
            Command command = Command.Parse("DeleteEvents EventTitle");
            string commandTitle = command.Parameters[0];

            Assert.AreEqual("EventTitle", commandTitle);
        }

        [TestMethod]
        public void TestParse_ListEvents_CommandNameShouldBeInitialized()
        {
            Command command = Command.Parse("ListEvents 2012-01-07T20:00:00 | 10");

            Assert.AreEqual("ListEvents", command.Name);
        }

        [TestMethod]
        public void TestParse_ListEvents_CommandDateShouldBeInitialized()
        {
            Command command = Command.Parse("ListEvents 2012-01-07T20:00:00 | 10");
            string commandDate = command.Parameters[0];

            Assert.AreEqual("2012-01-07T20:00:00", commandDate);
        }

        [TestMethod]
        public void TestParse_ListEvents_CommandNumberOfEventsToListShouldBeInitialized()
        {
            Command command = Command.Parse("ListEvents 2012-01-07T20:00:00 | 10");
            int numberOfEventsToList = int.Parse(command.Parameters[1]);

            Assert.AreEqual(10, numberOfEventsToList);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestParse_WhenCommandIsInvalid_ShouldThrowException()
        {
            Command command = Command.Parse("ListEvents");
        }
    }
}
