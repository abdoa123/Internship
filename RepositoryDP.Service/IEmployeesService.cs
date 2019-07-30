using RepositoryDP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RepositoryDP.Service
{
    public interface IEmployeesService
    {
        string Save(HttpPostedFileBase Photo);
        IEnumerable<Employees> getData();
        bool createEmployee(Employees employee, string photoPath);
        bool deleteEmployee(Employees employee);
        IEnumerable<Jobs> getJobs();
        IEnumerable<Attachments> getDocs();
    }
}
