using System.Web.Helpers;
using System.Web.Mvc;
using WebGridExample.ViewModel;

namespace WebGridExample.ModelBinders
{
    public class PagingBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var pageNum = request.QueryString.Get("Page");
            var size = request.QueryString.Get("Size");

            int pageNumber;
            if (!int.TryParse(pageNum, out pageNumber))
                pageNumber = 1; // Default Page

            var pageIndex = pageNumber - 1;

            int pageSize;
            if (!int.TryParse(size, out pageSize))
                pageSize = 10; // Default 10 records

            return new PagingModel
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageNumber = pageNumber
            };
        }
    }
}