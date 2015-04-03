using System.Linq;
using System.Text;
using WebGridExample.Models;

namespace WebGridExample.Formatters
{
    public class ExcelFormatter
    {
        private readonly IQueryable<User> _records;

        public ExcelFormatter(IQueryable<User> records)
        {
            _records = records;
        }

        public byte[] CreateXmlWorksheet()
        {
            var xmlTemplate = WebGridResources.ExcelXmlTemplate;
            var styles = GetStyles();
            var header = WriteHeader();
            var xmlData = GetRecords();

            var excelXml = string.Format("{0}{1}", header, xmlData);
            xmlTemplate = xmlTemplate.Replace("$ROWSPLACEHOLDER$", excelXml);
            xmlTemplate = xmlTemplate.Replace("$STYLEPLACEHOLDER$", styles);

            return Encoding.UTF8.GetBytes(xmlTemplate);
        }

        private string GetStyles()
        {
            return @"<Styles><Style ss:ID='s1'><NumberFormat ss:Format='dd/mm/yyyy\ hh:mm:ss' />"+
                "</Style></Styles>";

        }

        private string GetRecords()
        {
            var sb = new StringBuilder();
            foreach (var record in _records)
            {
                sb.Append("<Row ss:AutoFitHeight='0'>");
                sb.Append("<Cell><Data ss:Type='String'>" + record.Id + "</Data></Cell>");
                sb.Append("<Cell><Data ss:Type='String'>" + record.UserName + "</Data></Cell>");
                sb.Append("<Cell><Data ss:Type='String'>" + record.FirstName + "</Data></Cell>");
                sb.Append("<Cell><Data ss:Type='String'>" + record.LastName + "</Data></Cell>");
                sb.Append("<Cell ss:StyleID='s1'><Data ss:Type='Number'>" + 
                    record.LastLogin.ToOADate() + "</Data></Cell>");
                sb.Append("</Row>"); 
            }

            return sb.ToString();
        }

        private string WriteHeader()
        {
            var header = new StringBuilder();
            header.Append("<Row ss:AutoFitHeight='0'>");
            header.Append("<Cell><Data ss:Type='String'>Id</Data></Cell>");
            header.Append("<Cell><Data ss:Type='String'>User Name</Data></Cell>");
            header.Append("<Cell><Data ss:Type='String'>First Name</Data></Cell>");
            header.Append("<Cell><Data ss:Type='String'>Last Name</Data></Cell>");
            header.Append("<Cell><Data ss:Type='String'>Last Login</Data></Cell>");
            header.Append("</Row>"); 

            return header.ToString();
        }
    }
}