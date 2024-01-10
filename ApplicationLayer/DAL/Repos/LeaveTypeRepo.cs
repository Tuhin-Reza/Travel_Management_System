using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class LeaveTypeRepo : Repo, IRepo<LeaveType, int>
    {
        public LeaveType Create(LeaveType obj)
        {
            db.LeaveTypes.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public LeaveType Get(int id)
        {
            return db.LeaveTypes.Find(id);

        }

        public List<LeaveType> GetAll()
        {
            return db.LeaveTypes.ToList();
        }
        public LeaveType Update(LeaveType obj)
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

        public LeaveType Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.LeaveTypes.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }

        public LeaveType Name(string Name)
        {
            var existingfacilityType = (from lt in db.LeaveTypes
                                        where lt.LeaveTypeName == Name
                                        select lt).SingleOrDefault();
            return existingfacilityType;
        }

    }
}
