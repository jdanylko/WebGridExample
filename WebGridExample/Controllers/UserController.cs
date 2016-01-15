using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using WebGridExample.ActionResults;
using WebGridExample.CommandResults;
using WebGridExample.Formatters;
using WebGridExample.Interface;
using WebGridExample.Models;
using WebGridExample.Repository;
using WebGridExample.ViewModel;

namespace WebGridExample.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;

        public UserController() : this(new UserRepository()) { }
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: User
        public ActionResult Index(int? page)
        {
            var defaultPageSize = 5;
            var model = new UserViewModel
            {
                Users = _repository.GetPagedUsers(page, defaultPageSize)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection forms)
        {
            // Old way.
            // "select" variable will contain "select=2,3,4,5,10"
            //string[] checks = forms["select"].Split(',');

            //foreach (string checkedId in checks)
            //{
            //    if (checkedId.Contains("false")) continue;

            //    var id = checkedId;
            //    User user = _repository.First(e => e.Id.ToString() == id);
            //    if (!String.IsNullOrEmpty(forms["btnDelete"]))
            //    {
            //        _repository.Delete(user);
            //    }
            //    if (!String.IsNullOrEmpty(forms["btnSendEmail"]))
            //    {
            //        EMailTemplateService.SendTemplatedEMail(user);
            //    }
            //    if (!String.IsNullOrEmpty(forms["btnApprove"]))
            //    {
            //        // 
            //    }
            //    if (!String.IsNullOrEmpty(forms["Stuff1"]))
            //    {
            //        // blah
            //    }

            //    if (!String.IsNullOrEmpty(forms["Stuff2"]))
            //    {
            //        // blah
            //    }
            //}
            //return Redirect(Url.Content("~/"));

            // New way.
            return new UserCommandResult(
                this.ControllerContext,
                result => Redirect(Url.Content("~/"))
            );
        }

        [HttpPost]
        public ActionResult Export(ExportParameters model)
        {
            var records = _repository.GetAll();
            if (model.PagingEnabled)
            {
                records = records.Skip((model.CurrentPage-1) * model.PageSize)
                   .Take(model.PageSize);
            }

            if (model.OutputType.Equals(Output.Excel))
            {
                var excelFormatter = new ExcelFormatter(records);
                return new ExcelResult(excelFormatter.CreateXmlWorksheet(), "Sample.xlsx");
            }
            
            if (model.OutputType.Equals(Output.Csv))
            {
                return new CsvResult(records, "Sample.csv");
            }
           
            return Redirect(Url.Content("~/"));
        }

    }
}