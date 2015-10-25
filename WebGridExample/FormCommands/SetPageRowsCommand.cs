using System.Web.Mvc;

namespace WebGridExample.FormCommands
{
    public class SetPageRowsCommand : FormCommand
    {
        public SetPageRowsCommand(ControllerContext context)
        {
            CommandName = "rows";
            Context = context;
        }
        public override bool Execute(string input)
        {
            Result = input;
            return true;
        }
    }
}