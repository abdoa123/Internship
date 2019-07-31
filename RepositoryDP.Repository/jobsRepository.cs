using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryDP.Model;
using RepositoryDP;
using RepositoryDP.DAL;

namespace RepositoryDP.Repository
{
   public  class JobsRepository : IJobsRepository
    {
        //IUnitOfWork _unitOfWork = new IUnitOfWork() ;
        private  ApplicationDb _context;
        public JobsRepository()
        {
            _context = new ApplicationDb();
        }
        public bool createJob(Jobs job)
        {
            _context.jobs.Add(job);
            _context.SaveChanges();

            return true;
        }
        public bool update(Jobs job, Jobs job2)
        {

            job2.jobTitle = job.jobTitle;
            _context.SaveChanges();
            return true;
        }

        public bool delete(Jobs job)
        {
            try
            {
                _context.jobs.Remove(job);
                _context.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool deleteById(int id)
        {
            try
            {
                Jobs job = _context.jobs.Find(id);
                if(job != null)
                {
                    _context.jobs.Remove(job);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool deleteJob(int jobId)
        {
            var jobAndHisEMployee = (from jobTable in _context.jobs
                                     join empTable in _context.employees
                                     on jobId equals empTable.jobId
                                     select new
                                     {
                                         unit = jobTable,
                                         employees = empTable
                                     });
            var count = jobAndHisEMployee.ToList();
            if (count.Count() == 0)
            {
                Jobs obj = _context.jobs.Find(jobId);
                //db.jobs.Remove(obj);
                //db.SaveChanges();
                //message = "done";
                _context.jobs.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
               
            }
        }

        public IEnumerable<Jobs> getAll()
        {
            return _context.jobs.ToList();
        }

        public Jobs getById(int id)
        {
            return _context.jobs.Find(id);
        }

        public IEnumerable<Jobs> getData()
        {
            return _context.jobs.ToList();
        }

        public IEnumerable<Jobs> getJobs(int id)
        {
            var jobs = _context.jobs.Where(s => s.unitId == id).ToList();

            return jobs;

        }
    }
}
