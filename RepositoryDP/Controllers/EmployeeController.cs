using RepositoryDP.Model;
using RepositoryDP.DAL;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using RepositoryDP.Service;
using Kendo.Mvc.Extensions;
using RepositoryDP.Repository;
using System.Web;
using System.Linq;

namespace RepositoryDP.Controllers
{
    public class EmployeeController : Controller
    {
        private string message = "done";
        public static ApplicationDb db = new ApplicationDb(); // using data base
        public static IUnitOfWork obj = new UnitOfWork(db);
        public IEmployeesService EmpService = new EmployeesService(obj, new EmployeeRepository() , new JobsRepository());

        // GET: Employee
        public ActionResult Index()
        {
              ViewBag.Photo = System.IO.File.Exists(photoPath) ? photoPath : "/images/profile-default.png";

            db.Database.CreateIfNotExists();
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult createEmployee([DataSourceRequest]DataSourceRequest request, Employees employee)
        {
            if (employee.imagePath == null)
            {
                employee.imagePath = photoPath;
            }
            if (EmpService.createEmployee(employee, photoPath))
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
        string photoPath = "../Images/profile-default.png";

        public ActionResult getData([DataSourceRequest]DataSourceRequest request)
        {
            var employeeRecord = (from emp in db.employees
                                  join job in db.jobs on emp.jobId equals job.jobId
                                  select new
                                  {
                                      emp.empId,
                                      emp.firstName,
                                      emp.lastName,
                                      emp.phone,
                                      jobTitle = job.jobTitle,
                                      jobId = emp.jobId,
                                      emp.imagePath

                                  });
            return Json(employeeRecord.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public string Save(HttpPostedFileBase Photo)
        {
            return EmpService.Save(Photo);

        }

          public JsonResult getJobs()
        {
            return Json(EmpService.getJobs(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getDocs(int employeeId)
        {
            //var doc = db.docs.Where(s => s.empId == employeeId).ToList();
            var documents = (from empDoc in db.empDocs
                             join doc in db.docs
                             on empDoc.docId equals doc.docId
                             where employeeId == empDoc.empId
                             select new
                             {
                                 document = doc,
                             });
            return Json(new { Message = documents, JsonRequestBehavior.AllowGet });
        }
    }
}