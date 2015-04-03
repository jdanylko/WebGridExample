using System;
using System.IO;
using System.Web.Mvc;

namespace WebGridExample.ActionResults
{
    public class ExcelResult : ActionResult
    {
        private readonly Stream _excelStream;
        private readonly String _fileName;

        public ExcelResult(byte[] excel, String fileName)
        {
            _excelStream = new MemoryStream(excel);
            _fileName = fileName;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("We need a context!");
            }

            var response = context.HttpContext.Response;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("content-disposition", "attachment; filename=" + _fileName);
            
            byte[] buffer = new byte[4096];
            while (true)
            {
                var read = _excelStream.Read(buffer, 0, buffer.Length);
                if (read == 0) break;
                response.OutputStream.Write(buffer, 0, read);
            }

            response.End();
        }
    }
}