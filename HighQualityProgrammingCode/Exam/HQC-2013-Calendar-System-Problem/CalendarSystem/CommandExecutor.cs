namespace CalendarSystem
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class CommandExecutor
    {
        private readonly IEventsManager eventsManager;

        public CommandExecutor(IEventsManager eventsManager)
        {
            this.eventsManager = eventsManager;
        }

        public string ProcessCommand(Command command)
        {
            if (command.Name == "AddEvent")
            {
                return this.AddEvent(command);   
            }
            else if (command.Name == "DeleteEvents")
            {
                return this.DeleteEvents(command);
            }
            else if (command.Name == "ListEvents")
            {
                return this.ListEvents(command);
            }
            else
            {
                throw new ArgumentException("Unknown command: " + command.Name);
            }
        }

        private string AddEvent(Command command)
        {
            string commandTime = command.Parameters[0];
            DateTime eventDate = DateTime.ParseExact(commandTime, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string eventTitle = command.Parameters[1];
            Event newEvent;

            int numberOfParameters = command.Parameters.Length;
            if (numberOfParameters == 2)
            {
                newEvent = new Event(eventDate, eventTitle);
            }
            else
            {
                string eventLocation = command.Parameters[2];
                newEvent = new Event(eventDate, eventTitle, eventLocation);
            }

            this.eventsManager.AddEvent(newEvent);

            return "Event added";
        }

        private string DeleteEvents(Command command)
        {
            string eventTitle = command.Parameters[0];
            int eventsDeleted = this.eventsManager.DeleteEventsByTitle(eventTitle);

            if (eventsDeleted == 0)
            {
                return "No events found";
            }

            return string.Format("{0} events deleted", eventsDeleted);
        }

        private string ListEvents(Command command)
        {
            var eventsStartingDate = DateTime.ParseExact(command.Parameters[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var numberOfEventsToList = int.Parse(command.Parameters[1]);
            var events = this.eventsManager.ListEvents(eventsStartingDate, numberOfEventsToList).ToList();
            var result = new StringBuilder();

            if (!events.Any())
            {
                return "No events found";
            }

            foreach (var currentEvent in events)
            {
                result.AppendLine(currentEvent.ToString());
            }

            return result.ToString().Trim();
        }
    }
}