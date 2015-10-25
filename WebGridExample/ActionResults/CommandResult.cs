using System;
using System.Linq;
using System.Web.Mvc;
using WebGridExample.FormCommands;
using WebGridExample.Interface;

namespace WebGridExample.ActionResults
{
    public class CommandResult : ActionResult
    {
        public CommandList<IFormCommand> Commands { get; } = new CommandList<IFormCommand>();

        public string BatchName { get; set; }

        public FormCollection FormCollection { get; set; }

        public Func<IFormCommand, ActionResult> SuccessResult;

        public CommandResult(ControllerContext context, Func<IFormCommand, ActionResult> successResult)
            : this(context, successResult, String.Empty)
        { }

        public CommandResult(ControllerContext context, Func<IFormCommand, ActionResult> successResult,
            string triggerName)
        {
            BatchName = triggerName;
            FormCollection = new FormCollection(context.HttpContext.Request.Form);
            SuccessResult = successResult;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var command = GetKnownCommand();
            if (command != null)
                command.Execute(String.Empty);
            SuccessResult(command).ExecuteResult(context);
        }
        protected IFormCommand GetKnownCommand()
        {
            return Commands.FirstOrDefault(
                e => FormCollection.AllKeys.Any(f => f.Equals(e.CommandName)));
        }
    }
}