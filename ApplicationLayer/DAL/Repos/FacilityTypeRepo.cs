using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class FacilityTypeRepo : Repo, IRepo<FacilityType, int>
    {
        public FacilityType Create(FacilityType obj)
        {
            db.FacilityTypes.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public FacilityType Get(int id)
        {
            return db.FacilityTypes.Find(id);
        }

        public List<FacilityType> GetAll()
        {
            return db.FacilityTypes.ToList();
        }

        public FacilityType Update(FacilityType obj)
        {
            var ex = Get(obj.FacilityID);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            return null;
        }

        public FacilityType Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.FacilityTypes.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }

        public FacilityType Name(string facilityTypeName)
        {
            var existingfacilityType = (from TypeName in db.FacilityTypes
                                        where TypeName.FacilityName == facilityTypeName
                                        select TypeName).SingleOrDefault();
            return existingfacilityType;
        }
    }
}
