namespace FreeContent
{
    using System;
    using System.Linq;
    using System.Text;

    public interface ICommandExecutor
    {
        void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder output);
    }
}
