using System;
using System.Web.Mvc;
using WebGridExample.ActionResults;
using WebGridExample.FormCommands;
using WebGridExample.Interface;

namespace WebGridExample.CommandResults
{
    public class UserCommandResult : BatchCommandResult
    {
        public UserCommandResult(ControllerContext context, Func<IFormCommand, ActionResult> successResult)
            : base(context, successResult)
        {
            Commands.Clear();
            Commands.Add(new DeleteUserCommand(context));
            Commands.Add(new SendEmailCommand(context));
            Commands.Add(new SetPageRowsCommand(context));
        }
    }
}