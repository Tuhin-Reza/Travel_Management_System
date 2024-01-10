using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class DestinationCountryRepo : Repo, IRepo<DestinationCountry, int>
    {
        public DestinationCountry Create(DestinationCountry obj)
        {
            db.DestinationCountries.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public DestinationCountry Get(int id)
        {
            return db.DestinationCountries.Find(id);
        }

        public List<DestinationCountry> GetAll()
        {
            return db.DestinationCountries.ToList();
        }
        public DestinationCountry Update(DestinationCountry obj)
        {
            var ex = Get(obj.CountryID);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            return null;
        }

        public DestinationCountry Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.DestinationCountries.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }

        public DestinationCountry Name(string Name)
        {
            var existingCountry = (from dc in db.DestinationCountries
                                   where dc.CountryName == Name
                                   select dc).SingleOrDefault();
            return existingCountry;
        }

    }
}
