using System.Web.Mvc;

namespace WebGridExample.Interface
{
    public interface IFormCommand
    {
        string CommandName { get; set; }
        string Result { get; set; }
        bool Success { get; set; }
        ControllerContext Context { get; set; }
        bool Execute(string input);
    }
}