using System;
using System.Web.Mvc;
using WebGridExample.Repository;

namespace WebGridExample.FormCommands
{
    public class DeleteUserCommand : FormCommand
    {
        public DeleteUserCommand(ControllerContext context) : base(context)
        {
            CommandName = "btnDelete";
        }
        public override bool Execute(string input)
        {
            if (String.IsNullOrEmpty(input)) return false;

            var repository = new UserRepository();
            int userId;
            if (!Int32.TryParse(input, out userId))
            {
                return false;
            }

            var user = repository.GetById(userId);
            if (user != null)
            {
                repository.Delete(user);
            }
            try
            {
                repository.SaveChanges();
                Success = true;
            }
            catch
            {
                Success = false;
            }
            return Success;
        }
    }
}