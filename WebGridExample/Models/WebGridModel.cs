using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Helpers;

namespace WebGridExample.Models
{
    public class WebGridModel
    {
        public WebGrid WebGrid { get; set; }
        public HttpContextBase HttpContext { get; set; }
        public string TableStyle { get; set; }
        public string HeaderStyle { get; set; }
        public string FooterStyle { get; set; }
        public string RowStyle { get; set; }
        public string AlternatingRowStyle { get; set; }
        public string SelectedRowStyle { get; set; }
        public string Caption { get; set; }
        public bool DisplayHeader { get; set; }
        public bool FillEmptyRows { get; set; }
        public string EmptyRowCellValue { get; set; }
        public IEnumerable<WebGridColumn> Columns { get; set; }
        public IEnumerable<string> Exclusions { get; set; }
        public Func<dynamic, object> Footer { get; set; }
        public object HtmlAttributes { get; set; }
    }
}