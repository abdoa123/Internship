using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RepositoryDP.DAL;
using RepositoryDP.Model;
using RepositoryDP.Repository;
using RepositoryDP.Service;
using System.Linq;
using System.Web.Mvc;

namespace RepositoryDP.Controllers
{
    public class DepartmentsController : Controller
    {
        private string message = "Done";
        public static ApplicationDb db = new ApplicationDb();
        public static IUnitOfWork obj = new UnitOfWork(db);
        public IDepartmentsService DepService = new DepartmentsService(obj, new DepartmentsRepository());
        // GET: Departments
        public ActionResult Index()
        {
            db.Database.CreateIfNotExists();
            return View();
        }
        public ActionResult getData([DataSourceRequest]DataSourceRequest request)
        {

            return Json(DepService.getData().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult createDepartment([DataSourceRequest]DataSourceRequest request, Departments dep)
        {
           
                bool done = DepService.createDepartment(dep);
                return Json(new { Message = done, JsonRequestBehavior.AllowGet });

        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult deleteDepartment([DataSourceRequest]DataSourceRequest request, Departments dep)
        {
            bool done =DepService.deleteDepartment(dep);

            return Json(new { Message = done, JsonRequestBehavior.AllowGet });

        }

    }
}