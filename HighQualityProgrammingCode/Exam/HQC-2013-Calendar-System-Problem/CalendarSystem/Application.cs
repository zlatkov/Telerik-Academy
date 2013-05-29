namespace CalendarSystem
{
    using System;
    using System.Linq;

    public class Application
    {
        internal static void Main()
        {
            var eventsManager = new EventsManagerFast();
            var commandExecutor = new CommandExecutor(eventsManager);

            bool shouldReadCommands = true;

            while (shouldReadCommands)
            {
                string command = Console.ReadLine();
                if (command == "End" || string.IsNullOrEmpty(command))
                {
                    shouldReadCommands = false;
                }
                else
                {
                    Command parsedCommand = Command.Parse(command);
                    string commandResult = commandExecutor.ProcessCommand(parsedCommand);
                    Console.WriteLine(commandResult); 
                }
            }
        }
    }
}