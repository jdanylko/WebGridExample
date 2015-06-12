using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using WebGridExample.Models;
using WebGridExample.ViewModel;

namespace WebGridExample.ModelBinders
{
    public class UserViewModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext,
                                             ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var selectedList = new List<string>();
            if (!String.IsNullOrEmpty(request.Form.Get("select")))
            {
                var userIdList = request.Form.Get("select");
                selectedList = userIdList.Split(',').ToList<string>();
            }

            return new UserViewModel
            {
                SelectedUsers = selectedList.Select(e => new User { Id = Convert.ToInt32(e) }),
                Delete = !String.IsNullOrEmpty(request.Form.Get("btnDelete"))
            };
        }
    }
}