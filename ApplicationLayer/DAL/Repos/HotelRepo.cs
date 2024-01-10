using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class HotelRepo : Repo, IRepo<Hotel, int>
    {
        public Hotel Create(Hotel obj)
        {
            db.Hotels.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public Hotel Get(int id)
        {
            return db.Hotels.Find(id);
        }

        public List<Hotel> GetAll()
        {
            return db.Hotels.ToList();
        }

        public Hotel Update(Hotel obj)
        {
            var ex = Get(obj.HotelID);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            return null;
        }

        public Hotel Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.Hotels.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }


        public Hotel Name(string Name)
        {
            var existingHotelName = (from hotel in db.Hotels
                                     where hotel.HotelName == Name
                                     select hotel).SingleOrDefault();
            return existingHotelName;
        }
    }
}
