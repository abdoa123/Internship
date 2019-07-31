using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RepositoryDP.DAL;
using RepositoryDP.Model;
using RepositoryDP.Repositor;
using RepositoryDP.Repository;
using RepositoryDP.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace RepositoryDP.Controllers
{
    public class AttachmentsController : Controller
    {
        public static ApplicationDb db = new ApplicationDb(); // using data base
        public static IUnitOfWork obj = new UnitOfWork(db);
        public IAttachmentsService attachService = new AttachmentsService(obj, new AttachmentsRepository());
        private string message ="done";

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
        [HttpPost]
        public JsonResult UploadFile()
        {
            var fileName = "";
            EmpDocs empDoc = new EmpDocs();

            var empId = 0;
            var docId = 0;
            try
            {
                foreach (string file in Request.Files)
                {
                    string[] ids = file.Split(',');
                    int index = ids[0].IndexOf("=") + 1;
                    string id = ids[0].Substring(index);
                    empId = Int32.Parse(ids[0].Substring(index));
                    docId = Int32.Parse(ids[1].Substring(index));
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        // get a stream
                        var stream = fileContent.InputStream;
                        // and optionally write the file to disk
                        fileName = fileContent.FileName;
                        string[] paths = fileName.Split('\\');
                        if (paths != null)
                        {
                            fileName = paths.Last();
                        }
                        fileName = fileName.Replace(" ", String.Empty);
                        //fileName = "empId" + empId + "docId" + docId + ".png";

                        var path = Path.Combine(HostingEnvironment.MapPath("~/Images"), fileName);
                        var finalPath = "../Images/" + fileName;
                        fileName = "";
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                        empDoc.empId = empId;
                        empDoc.docId = docId;
                        empDoc.docPath = finalPath;
                        try
                        {
                            EmpDocs empdocs = db.empDocs.Find(empDoc.empId, empDoc.docId);
                            if (empdocs == null)
                                db.empDocs.Add(empDoc);
                            else
                                empdocs.docPath = empDoc.docPath;
                            message = "Done";
                        }
                        catch (Exception)
                        {
                            message = "Failed";
                        }
                        finally
                        {
                            db.SaveChanges();
                        }



                    }
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                message = "Failed";
                return Json(message);
            }

            return Json(message);
        }

    }
}