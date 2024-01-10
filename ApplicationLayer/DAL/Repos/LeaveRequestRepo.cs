using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class LeaveRequestRepo : Repo, IRepo<LeaveRequest, int>
    {
        public LeaveRequest Create(LeaveRequest obj)
        {
            db.LeaveRequests.Add(obj);
            db.SaveChanges();
            return obj;
        }


        public LeaveRequest Get(int id)
        {
            return db.LeaveRequests.Find(id);
        }

        public List<LeaveRequest> GetAll()
        {
            return db.LeaveRequests.ToList();

        }

        public LeaveRequest Update(LeaveRequest obj)
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

        public LeaveRequest Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.LeaveRequests.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }

        public LeaveRequest Name(string Name)
        {
            return null;
        }
    }
}
