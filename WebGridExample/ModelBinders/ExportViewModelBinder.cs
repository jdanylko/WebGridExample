using System;
using System.Web.Mvc;
using WebGridExample.ViewModel;

namespace WebGridExample.ModelBinders
{
    public class ExportViewModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            
            // Range
            var range = request.Form.Get("pageOptions");
            var pagingOptions = range == "pageCurrent" 
                ? RangeOptions.Current 
                : RangeOptions.All;
            
            // Output
            var output = request.Form.Get("exportType");
            var outputType = Output.Excel;
            switch (output)
            {
                case "exportCsv":
                    outputType = Output.Csv;
                    break;
            }

            int currentPage;
            if (!Int32.TryParse(request.Form.Get("CurrentPage"), out currentPage))
            {
                currentPage = 0;
            }

            int pageSize;
            if (!Int32.TryParse(request.Form.Get("RowsPerPage"), out pageSize))
            {
                pageSize = 0;
            }

            bool pagingEnabled;
            if (!bool.TryParse(request.Form.Get("PagingEnabled"), out pagingEnabled))
            {
                pagingEnabled = false;
            }
            
            return new ExportParameters
            {
                Range = pagingOptions,
                OutputType = outputType,
                CurrentPage = currentPage,
                PageSize = pageSize,
                PagingEnabled = pagingEnabled
            };
        }
    }
}