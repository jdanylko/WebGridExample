using System;
using System.Linq;
using System.Web.Mvc;
using WebGridExample.Interface;

namespace WebGridExample.ActionResults
{
    public class BatchCommandResult : CommandResult
    {
        public BatchCommandResult(ControllerContext context, Func<IFormCommand, ActionResult> successResult)
            : base(context, successResult)
        {
            // What is the name of the checkbox in the Grid?
            BatchName = "select";
        }
        public override void ExecuteResult(ControllerContext context)
        {
            ExecuteCommands();
            var command = ExecuteNonCommands(); // i.e. paging, etc.
            SuccessResult(command).ExecuteResult(context);
        }
        private IFormCommand ExecuteNonCommands()
        {
            foreach (var command in FormCollection)
            {
                var formCommand = Commands.FirstOrDefault(e => e.CommandName == command.ToString());
                if (formCommand == null) continue;

                var value = FormCollection[formCommand.CommandName];
                if (String.IsNullOrEmpty(value)) continue;

                var idList = value.Split(',');
                foreach (var valueList in idList)
                {
                    formCommand.Execute(valueList);
                }
                return formCommand;
            }
            return null;
        }
        private void ExecuteCommands()
        {
            if (!IsSelected) return;
            var idList = SelectionItem.Split(',');
            var command = GetKnownCommand();
            if (command != null)
            {
                foreach (var valueList in idList)
                {
                    command.Execute(valueList);
                }
            }
        }
        protected bool IsSelected
        {
            get
            {
                var result = false;
                if (FormCollection != null && FormCollection.Count > 0)
                {
                    result = !String.IsNullOrEmpty(FormCollection[BatchName]);
                }
                return result;
            }
        }
        protected string SelectionItem => FormCollection[BatchName];
    }
}