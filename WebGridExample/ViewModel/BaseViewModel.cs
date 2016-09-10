using System.Collections.Generic;
using System.Web.Mvc;
using WebGridExample.ModelBinders;
using WebGridExample.Models;

namespace WebGridExample.ViewModel
{
    [ModelBinder(typeof(WebGridModelBinder))]
    public class BaseViewModel
    {
        public IEnumerable<User> SelectedUsers { get; set; }
        public bool Delete { get; set; }

    }
}