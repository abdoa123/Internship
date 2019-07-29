using RepositoryDP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDP.Service
{
    public interface IDepartmentsService
    {
        IEnumerable<Departments> getData();
        bool createDepartment(Departments dep);
        bool deleteDepartment(Departments dep);
    }
}
