using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class DestinationCountryCityPlaceRepo : Repo, IRepo<DestinationCountryCityPlace, int>, IDestinationCountryCityPlacesRepo<DestinationCountryCityPlace, int>
    {
        public DestinationCountryCityPlace Create(DestinationCountryCityPlace obj)
        {
            db.DestinationCountryCityPlaces.Add(obj);
            db.SaveChanges();
            return obj;
        }



        public DestinationCountryCityPlace Get(int id)
        {
            return db.DestinationCountryCityPlaces.Find(id);
        }

        public List<DestinationCountryCityPlace> GetAll()
        {
            return db.DestinationCountryCityPlaces.ToList();
        }

        public DestinationCountryCityPlace Name(string Name)
        {
            throw new System.NotImplementedException();
        }

        public DestinationCountryCityPlace Update(DestinationCountryCityPlace obj)
        {
            var ex = Get(obj.PlaceID);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            return null;
        }
        public DestinationCountryCityPlace Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.DestinationCountryCityPlaces.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }

        public DestinationCountryCityPlace CheckCityPlace(DestinationCountryCityPlace obj)
        {
            var existingCity = (from place in db.DestinationCountryCityPlaces
                                where place.DestinationCountryCityId == obj.DestinationCountryCityId && place.PlaceName == obj.PlaceName
                                select place).SingleOrDefault();
            return existingCity;
        }
    }
}
