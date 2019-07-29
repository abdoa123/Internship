using RepositoryDP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDP.Repository
{
    public interface IDepartmentsRepository
    {
        IEnumerable<Departments> getData();
        Departments getDepartment(int depId);
        bool createDepartment(Departments dep);
        bool updateDepartment(Departments dep);
        bool deleteDepartment(int departmentID);
        IEnumerable<Departments> getAll();
        Departments getById(int id);
        bool add(Departments department);
        bool delete(Departments department);
        bool deleteById(int id);
    }
}