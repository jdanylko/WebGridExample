using System.Collections.Generic;
using System.Web.Mvc;
using WebGridExample.ModelBinders;
using WebGridExample.Models;

namespace WebGridExample.ViewModel
{
    [ModelBinder(typeof(UserViewModelBinder))]
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public User User { get; set; }

        public IEnumerable<User> SelectedUsers { get; set; }
        public bool Delete { get; set; }
    }
}