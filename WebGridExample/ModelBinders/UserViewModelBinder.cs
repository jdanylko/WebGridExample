using System;
using System.Collections.Generic;
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
            var list = new List<string>();
            var request = controllerContext.HttpContext.Request;

            if (request.Form.AllKeys.Contains("select"))
            {
                var userIdList = request.Form.Get("select");
                var idList = userIdList.Split(',');
                list.AddRange(idList);
            }

            return new WebGridBatchViewModel
            {
                SelectedUsers = list.Select(e => new User {Id = Convert.ToInt32(e)}),
                Delete = !String.IsNullOrEmpty(request.Form.Get("btnDelete"))
            };
        }
    }
}