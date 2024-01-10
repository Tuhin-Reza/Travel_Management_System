using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class PropertyTypeRepo : Repo, IRepo<PropertyType, int>
    {
        public PropertyType Create(PropertyType obj)
        {
            db.PropertyTypes.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public PropertyType Get(int id)
        {
            return db.PropertyTypes.Find(id);
        }

        public List<PropertyType> GetAll()
        {
            return db.PropertyTypes.ToList();
        }

        public PropertyType Update(PropertyType obj)
        {
            var ex = Get(obj.PropertyTypeID);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            return null;
        }

        public PropertyType Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.PropertyTypes.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }

        public PropertyType Name(string name)
        {
            var existingPropertyType = (from ptName in db.PropertyTypes
                                        where ptName.TypeName == name
                                        select ptName).SingleOrDefault();
            return existingPropertyType;
        }
    }
}
