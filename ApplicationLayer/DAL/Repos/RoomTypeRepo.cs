using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class RoomTypeRepo : Repo, IRepo<RoomType, int>
    {
        public RoomType Create(RoomType obj)
        {
            db.RoomTypes.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public RoomType Get(int id)
        {
            return db.RoomTypes.Find(id);
        }

        public List<RoomType> GetAll()
        {
            return db.RoomTypes.ToList();
        }

        public RoomType Update(RoomType obj)
        {
            var ex = Get(obj.RoomTypeID);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            return null;
        }

        public RoomType Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.RoomTypes.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }

        public RoomType Name(string roomType)
        {
            var existingRoomType = (from rtName in db.RoomTypes
                                    where rtName.RoomTypeName == roomType
                                    select rtName).SingleOrDefault();
            return existingRoomType;
        }
    }
}
