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
    public class DepartmentsService : IDepartmentsService
    {
        public IUnitOfWork _unitOfWork;
        public IDepartmentsRepository _departmentsRepository;

        public DepartmentsService(IUnitOfWork unitOfWork, IDepartmentsRepository departmentsRepository)
        {
            _unitOfWork = unitOfWork;
            _departmentsRepository = departmentsRepository;
        }

        public DepartmentsService()
        {
        }

        public bool createDepartment(Departments dep)
        {
            if (dep.depId == 0)
            {
                return _departmentsRepository.createDepartment(dep);
            }
            else
            {

                return _departmentsRepository.updateDepartment(dep);
            }
        }



        public bool deleteDepartment(Departments dep)
        {
            return _departmentsRepository.deleteDepartment(dep.depId);
        }

        public IEnumerable<Departments> getData()
        {
            return _departmentsRepository.getData();
        }
    }
}
