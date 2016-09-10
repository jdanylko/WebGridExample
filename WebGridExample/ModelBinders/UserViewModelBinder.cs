using System;
using System.Linq;
using System.Web.Mvc;
using WebGridExample.Models;
using WebGridExample.ViewModel;

namespace WebGridExample.ModelBinders
{
    public class WebGridModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var userIdList = request.Form.Get("select");
            var list = userIdList.Split(',');

            return new WebGridBatchViewModel
            {
                SelectedUsers = list.Select(e => new User {Id = Convert.ToInt32(e)}),
                Delete = !String.IsNullOrEmpty(request.Form.Get("btnDelete"))
            };
        }
    }
}