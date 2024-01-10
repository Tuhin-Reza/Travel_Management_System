using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class EmployeeSalaryRepo : Repo, IRepo<EmployeeSalary, int>
    {
        public EmployeeSalary Create(EmployeeSalary obj)
        {
            db.EmployeeSalaries.Add(obj);
            db.SaveChanges();
            return obj;

        }
        public EmployeeSalary Get(int id)
        {
            return db.EmployeeSalaries.Find(id);
        }

        public List<EmployeeSalary> GetAll()
        {
            return db.EmployeeSalaries.ToList();
        }
        public EmployeeSalary Update(EmployeeSalary obj)
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
        public EmployeeSalary Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.EmployeeSalaries.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }

        public EmployeeSalary Name(string Name)
        {
            //var existingfacilityType = (from es in db.EmployeeSalaries
            //                            where lt.LeaveTypeName == Name
            //                            select em).SingleOrDefault();
            //return existingfacilityType;
            return null;
        }
    }
}
