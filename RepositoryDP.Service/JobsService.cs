using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryDP.Model;
using RepositoryDP.Repository;
using RepositoryDP.DAL;

namespace RepositoryDP.Service
{
    public class JobsService : IJobsService
    {
        IUnitOfWork _unitOfWork;
        IJobsRepository _jobsRepository;

        public JobsService(IUnitOfWork unitOfWork, IJobsRepository jobsRepository)
        {
            _unitOfWork = unitOfWork;
            _jobsRepository = jobsRepository;
        }

        public bool createJob(Jobs job)
        {
             //Jobs jobFound = db.jobs.Find(job.jobId);
                //jobFound.jobTitle = job.jobTitle;
                //message = "Edit Done";
                Jobs jobFound = _jobsRepository.getById(job.jobId);
                if (jobFound != null)
                {
                    return _jobsRepository.update(job , jobFound);
                    
                }
                else
                {
                    
                    return _jobsRepository.createJob(job);
                }

        }
       
        public bool deleteJob(Jobs job)
        {
            return _jobsRepository.deleteJob(job.jobId);
        }

        public bool handleJobs(Jobs[] jobs)
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
                //return Json(new { Message = "Done", JsonRequestBehavior.AllowGet });
                return true;
            }
            catch (Exception)
            {
                return false;
            }

            //return Json(new { Message = "jobs are empty", JsonRequestBehavior.AllowGet });
        }
    }
}
