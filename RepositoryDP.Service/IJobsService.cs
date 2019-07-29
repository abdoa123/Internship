using RepositoryDP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDP.Service
{
    public interface IJobsService
    {
        bool createJob(Jobs job);
        bool deleteJob(Jobs job);
        bool handleJobs(Jobs[] jobs);
    }
}
