using System.Web.Mvc;
using WebGridExample.ModelBinders;

namespace WebGridExample.ViewModel
{
    public enum RangeOptions { Current, All }
    public enum Output { Excel, Csv }

    [ModelBinder(typeof(ExportViewModelBinder))]
    public class ExportParameters
    {
        public RangeOptions Range { get; set; }
        public Output OutputType { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool PagingEnabled { get; set; }
    }
}