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
using System.Web;

namespace RepositoryDP.Service
{
    public class EmployeesService : IEmployeesService
    {
        IUnitOfWork _unitOfWork;
        IEmployeesRepository _employeesRepository;
        IJobsRepository _JobRepo;

        public EmployeesService(IUnitOfWork unitOfWork, IEmployeesRepository employeesRepository,IJobsRepository job)
        {
            _unitOfWork = unitOfWork;
            _employeesRepository = employeesRepository;
            _JobRepo = job;
        }
       
  

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
                return _employeesRepository.UpdateEmployee(employee);
                
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
            return _JobRepo.getAll();
        }
        string photoPath = "../Images/profile-default.png";
        public string Save(HttpPostedFileBase Photo)
        {
            if (Photo != null)
            {
                string imageName = getPhotoName(Photo.FileName);
                photoPath = Path.Combine(HostingEnvironment.MapPath("~/Images"), imageName);
                Photo.SaveAs(photoPath);

                return photoPath;
            }
            return "Failed";
        }
        IEnumerable<Employees> IEmployeesService.getData()
        {
            throw new NotImplementedException();
        }
    }
}
