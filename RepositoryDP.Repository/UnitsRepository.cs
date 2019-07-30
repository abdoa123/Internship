using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryDP.Model;
using RepositoryDP.DAL;

namespace RepositoryDP.Repository
{
    public class UnitsRepository : IUnitsRepository
    {
        //IUnitOfWork _unitOfWork;
        private readonly ApplicationDb _context;

        public UnitsRepository()
        {
            _context = new ApplicationDb();
        }

        public bool add(Units unit)
        {
            try
            {
                _context.units.Add(unit);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool createUnits(Units unit)
        {
            _context.units.Add(unit);
            _context.SaveChanges();

            return true;
        }

        public bool delete(Units unit)
        {
            try
            {
                _context.units.Remove(unit);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteById(int id)
        {
            try
            {
                Units unit = _context.units.Find(id);
                if (unit != null)
                {
                    _context.units.Remove(unit);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteUnit(int unitId)
        {
            Units unit = _context.units.Find(unitId);
            _context.units.Remove(unit);
            _context.SaveChanges();

            return true;
        }

        public dynamic getAll()
        {
            var unit = (from UnitTbl in _context.units
                        join tblDep in _context.departments on UnitTbl.departmentId equals tblDep.depId
                        select new Units
                        {
                            unitName = UnitTbl.unitName,
                            unitCode = UnitTbl.unitCode,
                            departmentId = UnitTbl.departmentId,
                            departmentName = tblDep.departmentName,
                            unitId = UnitTbl.unitId
                        }).AsEnumerable();

            return unit;
        }

        public Units getById(int id)
        {
            return _context.units.Find(id);
        }



        public int getMaxId()
        {
            var id = _context.units.OrderByDescending(u => u.unitId).FirstOrDefault();
            if (id == null)
            {
                return 0;
            }

            return id.unitId;
        }
    }
}
