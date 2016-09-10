using System.Web.Helpers;
using System.Web.Mvc;
using WebGridExample.ModelBinders;

namespace WebGridExample.ViewModel
{
    [ModelBinder(typeof(PagingBinder))]
    public class PagingModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Sort { get; set; }
        public SortDirection SortDir { get; set; }
        public int PageNumber { get; set; }
    }
}