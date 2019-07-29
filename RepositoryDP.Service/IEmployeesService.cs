using RepositoryDP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDP.Service
{
    public interface IEmployeesService
    {
        IEnumerable<Employees> getData();
        bool createEmployee(Employees employee, string photoPath);
        bool deleteEmployee(Employees employee);
        IEnumerable<Jobs> getJobs();
        IEnumerable<Attachments> getDocs();
    }
}
