using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RepositoryDP.DAL;
using RepositoryDP.Repositor;
using RepositoryDP.Repository;
using RepositoryDP.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryDP.Controllers
{
    public class AttachmentsController : Controller
    {
        public static ApplicationDb db = new ApplicationDb(); // using data base
        public static IUnitOfWork obj = new UnitOfWork(db);
        public IAttachmentsService attachService = new AttachmentsService(obj, new AttachmentsRepository());
        // GET: Attachments
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getData([DataSourceRequest]DataSourceRequest request)
        {
            var documents = attachService.getData();
            return Json(documents.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        
    }
}