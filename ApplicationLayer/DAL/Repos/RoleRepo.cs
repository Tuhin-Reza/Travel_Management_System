using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class RoleRepo : Repo, IRepo<Role, int>
    {
        public Role Create(Role obj)
        {
            db.Roles.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public Role Get(int id)
        {
            return db.Roles.Find(id);

        }

        public List<Role> GetAll()
        {
            return db.Roles.ToList();
        }

        public Role Update(Role obj)
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

        public Role Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.Roles.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;

        }


        public Role Name(string roleName)
        {
            var existingEmployeeType = (from r in db.Roles
                                        where r.RoleName == roleName
                                        select r).SingleOrDefault();
            return existingEmployeeType;
        }
    }
}
