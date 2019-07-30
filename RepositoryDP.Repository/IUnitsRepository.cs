using RepositoryDP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDP.Repository
{
    public interface IUnitsRepository
    {
        bool createUnits(Units Unit);
        bool deleteUnit(int unitId);
        int getMaxId();

       dynamic getAll();
       
        Units getById(int id);
        bool add(Units unit);
        bool delete(Units unit);
        bool deleteById(int id);
    }
}
