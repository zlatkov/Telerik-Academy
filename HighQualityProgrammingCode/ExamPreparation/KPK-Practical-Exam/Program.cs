namespace FreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            //StringBuilder output = new StringBuilder();
            //Catalog catalog = new Catalog();
            //ICommandExecutor commandExecutor = new CommandExecutor();
            //List<ICommand> commands = GetUserInput();

            //foreach (ICommand command in commands)
            //{
            //    commandExecutor.ExecuteCommand(catalog, command, output); //this is how we do
            //}


            ////Console.BackgroundColor = ConsoleColor.DarkGreen;
            //Console.Write(output); //printing the output
        }

        private static List<ICommand> GetUserInput()
        {
            List<ICommand> commands = new List<ICommand>();
            bool end = false;

            do
            {
                string newCommand = Console.ReadLine();
                end = (newCommand.Trim() == "End");
                if (!end)
                {
                    commands.Add(new Command(newCommand));
                }
            }
            while (!end);

            return commands;
        }
    }
}
