using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class LeaveSheetRepo : Repo, IRepo<LeaveSheet, int>
    {
        public LeaveSheet Create(LeaveSheet obj)
        {
            db.LeaveSheets.Add(obj);
            db.SaveChanges();
            return obj;

        }

        public LeaveSheet Get(int id)
        {
            return db.LeaveSheets.Find(id);
        }

        public List<LeaveSheet> GetAll()
        {
            return db.LeaveSheets.ToList();
        }
        public LeaveSheet Update(LeaveSheet obj)
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

        public LeaveSheet Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.LeaveSheets.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }
        public LeaveSheet Name(string Name)
        {
            //var existingfacilityType = (from lt in db.LeaveTypes
            //                            where lt.LeaveTypeName == Name
            //                            select lt).SingleOrDefault();
            //return existingfacilityType;
            return null;
        }
    }
}
