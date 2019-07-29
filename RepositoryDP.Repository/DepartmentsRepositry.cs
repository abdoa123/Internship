using RepositoryDP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryDP.DAL;
using RepositoryDP.Repository;

namespace RepositoryDP.Repository
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
       
        private readonly ApplicationDb _context;
        public DepartmentsRepository()
        {
            _context = new ApplicationDb();
        }
        public bool createDepartment(Departments dep)
        {
            _context.departments.Add(dep);
            //_unitOfWork.Commit();
            _context.SaveChanges();

            return true;
        }
        public bool updateDepartment( Departments dep)
        {
          
            Departments department = getDepartment(dep.depId);
            if (department != null)
            {
                department.departmentName = dep.departmentName;
                department.departmentCode = dep.departmentCode;
                _context.SaveChanges();

                return true;

            }
            else
            {
                return false;
            }
        }
        public bool deleteDepartment(int departmentID)
        {
             var confirm = (from u in _context.units
                           join d in _context.departments on u.departmentId equals departmentID
                            select new
                           {
                               unit = u,
                               department = d
                           });

            var x = confirm.ToList();
            if (x.Count() == 0)
            {
                Departments department = _context.departments.Find(departmentID);
                _context.departments.Remove(department);
                _context.SaveChanges();
                return true;
            }
            else
            {
                //message = "you can't delete this as there are Units in this department";
                return false;
            }
         
        }

        public IEnumerable<Departments> getData()
        {
            return _context.departments.ToList();

        }

        public Departments getDepartment(int depId)
        {
            return _context.departments.Find(depId);
        }

        public IEnumerable<Departments> getAll()
        {
            return _context.departments.ToList();
        }

        public Departments getById(int id)
        {
            return _context.departments.Find(id);
        }

        public bool add(Departments department)
        {
            try
            {
                _context.departments.Add(department);
                _context.SaveChanges();
                //_unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool delete(Departments department)
        {
            try
            {
                _context.departments.Remove(department);
                _context.SaveChanges();
                //_unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteById(int id)
        {
            try
            {
                Departments dep = _context.departments.Find(id);
                if (dep != null)
                {
                    _context.departments.Remove(dep);
                    _context.SaveChanges();
                    //_unitOfWork.Commit();
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
                return true;
            }
        }
    }
}
