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

        #region WebGrid Batch

        // GET: User
        public ActionResult WebGridBatch()
        {
            var model = new WebGridBatchViewModel
            {
                Users = _repository.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult WebGridBatch(WebGridBatchViewModel model)
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


        #endregion

        #region WebGrid Excel

        // GET: User
        public ActionResult WebGridExcel()
        {
            var model = new WebGridExcelViewModel
            {
                Users = _repository.GetAll()
            };
            return View(model);
        }

        #endregion

        #region WebGrid CSV

        // GET: User
        public ActionResult WebGridCSV()
        {
            var model = new WebGridExcelViewModel
            {
                Users = _repository.GetAll()
            };
            return View(model);
        }

        #endregion

        #region WebGrid Lazy-Loading webAPI

        public ActionResult WebGridLLWebApi(int? page)
        {
            var defaultPageSize = 5;
            var model = new WebGridWebApiViewModel
            {
                Users = _repository.GetPagedUsers(page, defaultPageSize)
            };
            return View(model);
        }

        #endregion

        #region WebGrid Lazy-Loading SignalR

        public ActionResult WebGridLLSignalR(int? page)
        {
            var defaultPageSize = 5;
            var model = new WebGridWebApiViewModel
            {
                Users = _repository.GetPagedUsers(page, defaultPageSize)
            };
            return View(model);
        }

        #endregion
        
        #region WebGrid Inline Editing

        public ActionResult WebGridInlineEditing(int? page)
        {
            var defaultPageSize = 5;
            var model = new WebGridWebApiViewModel
            {
                Users = _repository.GetPagedUsers(page, defaultPageSize)
            };
            return View(model);
        }

        #endregion

        #region WebGrid Validating

        public ActionResult WebGridValidating(int? page)
        {
            var defaultPageSize = 5;
            var model = new WebGridWebApiViewModel
            {
                Users = _repository.GetPagedUsers(page, defaultPageSize)
            };
            return View(model);
        }

        #endregion

        #region WebGrid Excel Filtering

        public ActionResult WebGridExcelFiltering()
        {
            var model = new WebGridBatchViewModel
            {
                Users = _repository.GetAll()
            };
            return View(model);
        }


        #endregion

        [HttpPost]
        public ActionResult Export(ExportParameters model)
        {
            var records = _repository.GetAll();
            if (model.PagingEnabled)
            {
                records = records.Skip((model.CurrentPage - 1) * model.PageSize)
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