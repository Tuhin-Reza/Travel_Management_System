using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class PropertyCategoryRepo : Repo, IRepo<PropertyCategory, int>
    {
        public PropertyCategory Create(PropertyCategory obj)
        {
            db.PropertyCategories.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public PropertyCategory Get(int id)
        {
            return db.PropertyCategories.Find(id);
        }

        public List<PropertyCategory> GetAll()
        {
            return db.PropertyCategories.ToList();
        }

        public PropertyCategory Update(PropertyCategory obj)
        {
            var ex = Get(obj.CategoryID);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            return null;
        }

        public PropertyCategory Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.PropertyCategories.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }

        public PropertyCategory Name(string categoryName)
        {
            var existingCategoryName = (from cName in db.PropertyCategories
                                        where cName.CategoryName == categoryName
                                        select cName).SingleOrDefault();
            return existingCategoryName;
        }
    }
}
