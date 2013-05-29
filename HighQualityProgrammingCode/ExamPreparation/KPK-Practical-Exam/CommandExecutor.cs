
namespace FreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder result)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    {
                        this.AddContent(ContentType.Book, catalog, command, result);
                        break;
                    } 

                case CommandType.AddMovie:
                    {
                        this.AddContent(ContentType.Movie, catalog, command, result);
                        break;
                    }

                case CommandType.AddSong:
                    {
                        this.AddContent(ContentType.Music, catalog, command, result);
                        break;
                    }

                case CommandType.AddApplication:
                    {
                        this.AddContent(ContentType.Application, catalog, command, result);
                        break;
                    }

                case CommandType.Update:
                    {
                        this.UpdateContent(catalog, command, result);
                        break;
                    }

                case CommandType.Find:
                    {
                        this.FindContent(catalog, command, result);
                        break;
                    }

                default:
                    {
                        throw new InvalidCastException("Unknown command!");
                    }
            }
        }
        private void AddContent(ContentType type, ICatalog catalog, ICommand command, StringBuilder result)
        {
            catalog.Add(new Content(type, command.Parameters));
            string updateSring = String.Format("{0} added", type.ToString());
            this.UpdateResult(result, updateSring);
        }

        private void FindContent(ICatalog catalog, ICommand command, StringBuilder result)
        {
            if (command.Parameters.Length != 2)
            {
                throw new FormatException("Invalid number of parameters!");
            }

            int numberOfElementsToList = int.Parse(command.Parameters[1]);
            IEnumerable<IContent> foundContent = catalog.GetListContent(command.Parameters[0], numberOfElementsToList);
            if (foundContent.Count() == 0)
            {
                this.UpdateResult(result, "No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    this.UpdateResult(result, content.TextRepresentation);
                }
            }
        }

        private void UpdateContent(ICatalog catalog, ICommand command, StringBuilder result)
        {
            if (command.Parameters.Length != 2)
            {
                throw new FormatException("Invalid number of parameters!");
            }

            string updateString = String.Format("{0} items updated", catalog.UpdateContent(command.Parameters[0], command.Parameters[1]));
            this.UpdateResult(result, updateString);
        }

        private void UpdateResult(StringBuilder result, string updateString)
        {
            result.AppendLine(updateString);
        }

    }

}
