using RepositoryDP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDP.Repository
{
    public interface IJobsRepository
    {
        IEnumerable<Jobs> getData();
        bool createJob(Jobs job);
        bool deleteJob(int jobId);
        bool update(Jobs job , Jobs job2);
        IEnumerable<Jobs> getAll();
        Jobs getById(int id);
        IEnumerable<Jobs> getJobs(int id);

    }
}
