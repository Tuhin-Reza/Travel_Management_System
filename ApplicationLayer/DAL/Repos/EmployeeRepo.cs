using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class EmployeeRepo : Repo, IEmployeeRepo<Employee, int>
    {
        public Employee Create(Employee obj)
        {
            db.Employees.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public List<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public Employee Update(Employee obj)
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

        public Employee Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.Employees.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }

        public List<Employee> GetByStatus(string status)
        {
            var existingEmployee = (from empl in db.Employees
                                    where empl.Status == status
                                    select empl).ToList();
            return existingEmployee;
        }

        public void UpdateStatus(int id, string newStatus)
        {
            var existingEmployee = (from empl in db.Employees
                                    where empl.Id == id
                                    select empl).SingleOrDefault();
            var ex = Get(id);
            if (ex != null)
            {
                ex.Status = newStatus;
                db.SaveChanges();
            }
        }

        public Employee Name(string employeeName)
        {
            var existingEmployee = (from emplName in db.Employees
                                    where emplName.FirstName == employeeName
                                    select emplName).SingleOrDefault();
            return existingEmployee;
        }

        public Employee email(string email)
        {
            var existingEmployee = (from empl in db.Employees
                                    where empl.EmailAddress == email
                                    select empl).SingleOrDefault();
            return existingEmployee;
        }
    }
}
