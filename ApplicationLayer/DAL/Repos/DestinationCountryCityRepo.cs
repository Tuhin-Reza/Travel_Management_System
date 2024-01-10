using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class DestinationCountryCityRepo : Repo, IRepo<DestinationCountryCity, int>, IDestinationCountryCityRepo<DestinationCountryCity, int>
    {
        public DestinationCountryCity Create(DestinationCountryCity obj)
        {
            db.DestinationCountryCities.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public DestinationCountryCity Get(int id)
        {
            return db.DestinationCountryCities.Find(id);
        }

        public List<DestinationCountryCity> GetAll()
        {
            return db.DestinationCountryCities.ToList();
        }
        public DestinationCountryCity Update(DestinationCountryCity obj)
        {
            var ex = Get(obj.CityID);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            return null;
        }

        public DestinationCountryCity Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.DestinationCountryCities.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }

        public DestinationCountryCity Name(string Name)
        {
            throw new System.NotImplementedException();
        }

        public DestinationCountryCity CheckCity(DestinationCountryCity obj)
        {
            var existingCity = (from city in db.DestinationCountryCities
                                where city.DestinationCountryID == obj.DestinationCountryID && city.CityName == obj.CityName
                                select city).SingleOrDefault();
            return existingCity;
        }
    }
}
