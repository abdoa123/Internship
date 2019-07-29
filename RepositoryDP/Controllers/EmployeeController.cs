using RepositoryDP.Model;
using RepositoryDP.DAL;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using RepositoryDP.Service;
using Kendo.Mvc.Extensions;

namespace RepositoryDP.Controllers
{
    public class EmployeeController : Controller
    {
        private string message = "done";
        public static ApplicationDb db = new ApplicationDb(); // using data base
        public IUnitOfWork obj = new UnitOfWork(db);
        public IEmployeesService EmpService = new EmployeesService();

        // GET: Employee
        public ActionResult Index()
        {
            //  ViewBag.Photo = System.IO.File.Exists(photoPath) ? photoPath : "/images/profile-default.png";

            db.Database.CreateIfNotExists();
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult createEmployee([DataSourceRequest]DataSourceRequest request, Employees employee)
        {

            if (EmpService.createEmployee(employee, "/images/profile-default.png"))
            {

                return Json(new { message, JsonRequestBehavior.AllowGet });
             }
            else
            {
                return Json(new { message = "not done", JsonRequestBehavior.AllowGet });
            }

        }
        public ActionResult deleteEmployee([DataSourceRequest] DataSourceRequest request, Employees emp)
        {

            if (EmpService.deleteEmployee(emp))
            {
                return Json(new[] { emp }.ToDataSourceResult(request, ModelState));
            }
            else
            {
                return Json(new[] { emp }.ToDataSourceResult(request, ModelState));
            }

        }
        public ActionResult getData([DataSourceRequest]DataSourceRequest request)
        {

            return Json(EmpService.getData().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
          public JsonResult getJobs()
        {
            return Json(EmpService.getJobs(), JsonRequestBehavior.AllowGet);
        }

        }
}