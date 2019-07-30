using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryDP.Model;
using RepositoryDP.Repository;
using RepositoryDP.DAL;

namespace RepositoryDP.Service
{
    public class UnitsService : IUnitsService 
    {
        IUnitOfWork _unitOfWork;
        IUnitsRepository _unitsRepository;
        IJobsRepository _jobRepository ;
        public static ApplicationDb db = new ApplicationDb();


        public UnitsService(IUnitOfWork unitOfWork, IUnitsRepository unitsRepository, IJobsRepository jobsRepository)
        {
            _unitOfWork = unitOfWork;
            _unitsRepository = unitsRepository;
            _jobRepository = jobsRepository;
        }

        public bool createUnits(Units unit)
        {
            try
            {
                //Units newUnit = db.units.Find(unit.unitId);
                //newUnit.unitName = unit.unitName;
                //newUnit.unitCode = unit.unitCode;
                //newUnit.departmentId = unit.departmentId;
                //db.SaveChanges();
                Units unitFound = _unitsRepository.getById(unit.unitId);
                if(unitFound != null)
                {
                    unitFound.unitName = unit.unitName;
                    unitFound.unitCode = unit.unitCode;
                    unitFound.departmentId = unit.departmentId;
                    _unitOfWork.Commit();
                    return true;
                }
                else
                {
                    _unitsRepository.add(unit);
                    _unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception)
            {
                //db.units.Add(unit);
                return false;
            }
            // return Json(new[] { unit }.ToDataSourceResult(request, ModelState));
        }

        public bool deleteUnit(Units unit)
        {
            //var confirm = (from u in _unitOfWork.units.getData()
            //               join j in _unitOfWork.jobs.getData() on unit.unitId equals j.unitId
            //               select new
            //               {
            //                   units = u,
            //                   jobs = j
            //               });
            //var count = confirm.ToList();

                //Units obj = db.units.Find(unit.unitId);
                //db.units.Remove(obj);
                //db.SaveChanges();
                //message = "done";
                _unitsRepository.deleteById(unit.unitId);
                _unitOfWork.Commit();
                return true;
            }
           
            //return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        

        public dynamic getData()
        {
          var   unitRecord = _unitsRepository.getAll();
            return unitRecord;
            //return Json(unitRecord.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

      
        public IEnumerable<Jobs> getJobs(int id)
        {
            return _jobRepository.getJobs(id);
        }

        public int getMaxId()
        {
            return _unitsRepository.getMaxId();
        }

        public IEnumerable<Attachments> getDepartments()
        {
            return _unitOfWork.attachments.getData();
        }
    }
}
