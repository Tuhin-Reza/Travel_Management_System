using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class EmployeeTypeRepo : Repo, IRepo<EmployeeType, int>
    {
        public EmployeeType Create(EmployeeType obj)
        {
            db.EmployeeTypes.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public EmployeeType Get(int id)
        {
            return db.EmployeeTypes.Find(id);
        }

        public List<EmployeeType> GetAll()
        {
            return db.EmployeeTypes.ToList();
        }

        public EmployeeType Name(string employeeTypeName)
        {
            var existingEmployeeType = (from emplType in db.EmployeeTypes
                                        where emplType.EmployeeTypeName == employeeTypeName
                                        select emplType).SingleOrDefault();
            return existingEmployeeType;


        }

        public EmployeeType Update(EmployeeType obj)
        {
            var ex = Get(obj.Id);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            return null;
        }

        public EmployeeType Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.EmployeeTypes.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }
    }
}
