using RepositoryDP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryDP.Service;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RepositoryDP.Model;
using RepositoryDP.Repository;

namespace RepositoryDP.Controllers
{
    public class UnitsController : Controller
    {

        public static ApplicationDb db = new ApplicationDb();
        public static IUnitOfWork obj = new UnitOfWork(db);
        public IDepartmentsService _depService = new DepartmentsService(obj, new DepartmentsRepository());
        public IUnitsService unitService = new UnitsService(obj , new UnitsRepository() , new JobsRepository());

        // GET: Units
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getData([DataSourceRequest]DataSourceRequest request)
        {
            return Json(unitService.getData().ToList().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult createUnits([DataSourceRequest]DataSourceRequest request, Units unit)
        {
            bool done = unitService.createUnits(unit);

            return Json(new[] { unit }.ToDataSourceResult(request, ModelState));

        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult deleteUnit([DataSourceRequest]DataSourceRequest request, Units unit)
        {
            bool done = unitService.deleteUnit(unit);
            return Json(new { Message = done, JsonRequestBehavior.AllowGet });
        }
        public JsonResult getMaxId()
        {
            int id = unitService.getMaxId();
            if (id == 0)
            {
                return Json(new { Message = 0, JsonRequestBehavior.AllowGet });
            }

            return Json(new { Message = id, JsonRequestBehavior.AllowGet });

        }
        public JsonResult getJobs(int unitId)
        {
            return Json(new { Message = unitService.getJobs(unitId), JsonRequestBehavior.AllowGet });
        }
        public JsonResult getDepartments()
        {
            return Json(_depService.getData(), JsonRequestBehavior.AllowGet);
        }
    }
}
