using System.Web.Mvc;

namespace WebGridExample.FormCommands
{
    public class SetPageRowsCommand : FormCommand
    {
        public SetPageRowsCommand(ControllerContext context)
        {
            CommandName = "size";
            Context = context;
        }
        public override bool Execute(string input)
        {
            Result = input;
            return true;
        }
    }
}