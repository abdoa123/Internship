using RepositoryDP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryDP.DAL;
namespace RepositoryDP.Repository
{
    public class EmployeeRepository : IEmployeesRepository
    {
        IUnitOfWork _unitOfWork;
        private readonly ApplicationDb _context;

        public EmployeeRepository()
        {
            _context = new ApplicationDb();
        }

        public bool createEmployee(Employees employee ,string photoPath)
        {
            if (employee.imagePath == null)
            {
                employee.imagePath = photoPath;
            }
            _context.employees.Add(employee);
            _context.SaveChanges();

            // _unitOfWork.Commit();
            return true;

        }
        public bool UpdateEmployee(Employees emp)
        {
            Employees employee = _context.employees.Find(emp.empId);
            employee.firstName = emp.firstName;
            employee.lastName = emp.lastName;
            employee.phone = emp.phone;
            employee.jobId = emp.jobId;
            employee.imagePath = emp.imagePath;
            _context.SaveChanges();
            //_unitOfWork.Commit();
            return true;
        }

        public bool deleteEmployee(int EmployeeID)
        {
           Employees emp = _context.employees.Find(EmployeeID);
            _context.employees.Remove(emp);
            //_unitOfWork.Commit();
            _context.SaveChanges();

            return true;

        }

        public object getData()
        {
            var employeeRecord = (from emp in _context.employees
                                  join job in _context.jobs on emp.jobId equals job.jobId
                                  select new
                                  {
                                      emp.empId,
                                      emp.firstName,
                                      emp.lastName,
                                      emp.phone,
                                      jobTitle = job.jobTitle,
                                      jobId = emp.jobId,
                                      emp.imagePath
                                  });
            return employeeRecord;
        }

      
        public void getImages(int employeeId)
        {
            var docs = (from empDoc in _context.empDocs
                        join doc in _context.docs
                       on empDoc.docId equals doc.docId
                        where empDoc.empId == employeeId
                       select new
                      {
                            doc.docId,
                          docName = doc.docName,
                       empDoc.docPath,
                          empDoc.empId
                        });
            
        }

        public IEnumerable<Employees> getAll()
        {
            return _context.employees.ToList();
        }

        public Employees getById(int id)
        {
            return _context.employees.Find(id);
        }

        public bool add(Employees employee)
        {
            try
            {
                _context.employees.Add(employee);
                _context.SaveChanges();
                //_unitOfWork.Commit();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool delete(Employees employee)
        {
            try
            {
                _context.employees.Remove(employee);
                _context.SaveChanges();
                //_unitOfWork.Commit();
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
                Employees emp = _context.employees.Find(id);
                if(emp != null)
                {
                    _context.employees.Remove(emp);
                    _context.SaveChanges();
                    //_unitOfWork.Commit();
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
