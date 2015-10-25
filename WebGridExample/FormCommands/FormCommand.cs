using System.Web.Mvc;
using WebGridExample.Interface;

namespace WebGridExample.FormCommands
{
    public abstract class FormCommand : IFormCommand
    {
        public string CommandName { get; set; }
        public string Result { get; set; }
        public bool Success { get; set; }
        public ControllerContext Context { get; set; }
        public virtual bool Execute(string input) { return true; }
        public virtual bool Execute(string input, string input2) { return true; }
        protected FormCommand() : this(null) { }
        protected FormCommand(ControllerContext context)
        {
            Context = context;
            Success = true;
        }
    }
}