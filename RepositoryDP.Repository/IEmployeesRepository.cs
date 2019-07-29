using RepositoryDP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDP.Repository
{
    public interface IEmployeesRepository
    {
        object  getData();
        bool createEmployee(Employees employee , string photoPath);
        bool deleteEmployee(int EmployeeID);
       // JsonResult getImages(int employeeId);
        bool UpdateEmployee(Employees emp);

        IEnumerable<Employees> getAll();
        Employees getById(int id);
        bool add(Employees employee);
        bool delete(Employees employee);
        bool deleteById(int id);
    }
}
