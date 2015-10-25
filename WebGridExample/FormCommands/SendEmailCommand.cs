using System;
using System.Web.Mvc;

namespace WebGridExample.FormCommands
{
    public class SendEmailCommand : FormCommand
    {
        public SendEmailCommand(ControllerContext context) : base(context)
        {
            CommandName = "btnSendEmail";
        }
        public override bool Execute(string input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            var userId = input;
            
            // EMailTemplateService.SendTemplatedEMail(userId);

            return true;
        }
    }
}