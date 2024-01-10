using DAL.EF.Models;
using DAL.Interfaces;
using System.Linq;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IUserRepo<User, int>, IAuth<User>
    {
        public User Auth(User user)
        {
            var data = (from u in db.Users
                        where u.Username.Equals(user.Username)
                             && u.Password.Equals(user.Password)
                        select u).SingleOrDefault();

            if (data == null)
            {
                return null;
            }
            return data;
        }

        public void create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public void UpdatePassword(int id, string newPassword)
        {

            var existingUser = (from user in db.Users
                                where user.EmpId == id
                                select user).SingleOrDefault();
            if (existingUser != null)
            {
                existingUser.Password = newPassword;
                db.SaveChanges();
            }
        }
    }
}
