using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryDP.Model;
using RepositoryDP.Repository;
using System.IO;
using System.Web.Hosting;
using RepositoryDP.DAL;
namespace RepositoryDP.Service
{
    public class EmployeesService : IEmployeesService
    {
        IUnitOfWork _unitOfWork;
        IEmployeesRepository _employeesRepository;

  

        //string photoPath = "../Images/profile-default.png";
        private string getPhotoName(string path)
        {
            string[] dir = path.Split('\\');
            return dir.Last();
        }

        public bool createEmployee(Employees employee, string photoPath)
        {
            if (employee.empId == 0)
            {
                //if (employee.imagePath == null)
                //{
                //    employee.imagePath = photoPath;
                //}
                _employeesRepository.createEmployee(employee, photoPath);
                return true;
            }
            else
            {
                Employees emp = _employeesRepository.getById(employee.empId);
                emp.firstName = employee.firstName;
                emp.lastName = employee.lastName;
                emp.phone = employee.phone;
                emp.jobId = employee.jobId;
                string photoName = getPhotoName(emp.imagePath);
                if (System.IO.File.Exists(Path.Combine(HostingEnvironment.MapPath("~/Images"), photoName)) && emp.imagePath != "../Images/profile-default.png")
                {
                    System.IO.File.Delete(Path.Combine(HostingEnvironment.MapPath("~/Images"), photoName));
                }
                emp.imagePath = employee.imagePath;
                _unitOfWork.Commit();
                return true;
            }
            //db.SaveChanges();

            //return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        public bool deleteEmployee(Employees employee)
        {
            Employees emp = _employeesRepository.getById(employee.empId);
            string photoName = getPhotoName(emp.imagePath);
            if (System.IO.File.Exists(Path.Combine(HostingEnvironment.MapPath("~/Images"), photoName)) && emp.imagePath != "../Images/profile-default.png")
            {
                System.IO.File.Delete(Path.Combine(HostingEnvironment.MapPath("~/Images"), photoName));
            }
            _employeesRepository.delete(emp);
            //db.SaveChanges();
            _unitOfWork.Commit();
            return true;
            //return Json(new[] { emp }.ToDataSourceResult(request, ModelState));
        }

        public  object getData()
        {
            var employeeRecord = _employeesRepository.getData();
            return employeeRecord;

        }

        public IEnumerable<Attachments> getDocs()
        {
            return _unitOfWork.attachments.getData();
        }

        public IEnumerable<Jobs> getJobs()
        {
            return _unitOfWork.jobs.getData();
        }

        IEnumerable<Employees> IEmployeesService.getData()
        {
            throw new NotImplementedException();
        }
    }
}
