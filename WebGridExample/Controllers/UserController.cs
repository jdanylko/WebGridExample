using System.IO;
using System.Linq;
using System.Web.Mvc;
using WebGridExample.ActionResults;
using WebGridExample.Formatters;
using WebGridExample.Interface;
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
        public ActionResult Index(UserViewModel model)
        {
            if (model.Delete)
            {
                foreach (var user in model.SelectedUsers)
                {
                    var loadedUser = _repository.GetById(user.Id);
                    _repository.Delete(loadedUser);
                    _repository.SaveChanges();
                }
            }

            return Redirect(Url.Content("~/"));
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