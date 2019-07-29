using RepositoryDP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDP.Service
{
    public interface IUnitsService
    {
        IEnumerable<Units> getData();
        bool createUnits(Units unit);
        bool deleteUnit(Units unit);
        int getMaxId();
        IEnumerable<Jobs> getJobs(int id);
        IEnumerable<Attachments> getDepartments();
    }
}
