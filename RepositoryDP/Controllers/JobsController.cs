using RepositoryDP.Model;
using RepositoryDP.DAL;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using RepositoryDP.Service;
using Kendo.Mvc.Extensions;
using System;

namespace RepositoryDP.Controllers
{
    public class JobsController : Controller
    {
      
       
        public IJobsService JobService = new JobsService();
        // GET: Jobs
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult createJob(Jobs job)
        {
           bool done = JobService.createJob(job);
            return Json(new { Message = done, JsonRequestBehavior.AllowGet });
        }

        public ActionResult deleteJob(Jobs job)
        {
            bool done = JobService.deleteJob(job);
            return Json(new { Message = done, JsonRequestBehavior.AllowGet });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult handleJobs([DataSourceRequest]DataSourceRequest request, Jobs[] jobs)
        {
            try
            {
                for (int i = 0; i < jobs.Length; i++)
                {
                    if (jobs[i].jobTitle == null)
                    {
                        deleteJob(jobs[i]);
                    }
                    else
                    {
                        createJob(jobs[i]);
                    }
                }
                return Json(new { Message = "Done", JsonRequestBehavior.AllowGet });
            }
            catch (Exception)
            {

            }

            return Json(new { Message = "jobs are empty", JsonRequestBehavior.AllowGet });
        }
    }
}