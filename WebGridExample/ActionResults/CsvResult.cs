using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebGridExample.Formatters;
using WebGridExample.Models;

namespace WebGridExample.ActionResults
{
    public class CsvResult : ActionResult
    {
        private readonly IQueryable<User> _records;
        private readonly string _filename;

        public CsvResult(IQueryable<User> records, string filename)
        {
            _records = records;
            _filename = filename;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var sb = new StringBuilder();
            sb.Append(_records.ToCsv<User>(","));

            var response = context.HttpContext.Response;
            response.ContentType = "text/csv";
            response.AddHeader("content-disposition", 
                String.Format("attachment; filename={0}", _filename));

            response.Write(sb.ToString());

            response.Flush();
            response.End();
        }
    }
}