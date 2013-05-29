namespace CalendarSystem
{
    using System;
    using System.Linq;

    public class Command
    {
        private Command(string name, string[] parameters)
        {
            this.Name = name;
            this.Parameters = parameters;
        }
        
        public string Name { get; private set; }

        public string[] Parameters { get; private set; }

        public static Command Parse(string lineToParse)
        {
            int commandNameEndIndex = lineToParse.IndexOf(' ');
            if (commandNameEndIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + lineToParse);
            }

            string commandName = lineToParse.Substring(0, commandNameEndIndex);

            string parameters = lineToParse.Substring(commandNameEndIndex + 1);
            var commandParameters = parameters.Split('|');
            for (int i = 0; i < commandParameters.Length; i++)
            {
                commandParameters[i] = commandParameters[i].Trim();
            }

            return new Command(commandName, commandParameters);
        }
    }
}