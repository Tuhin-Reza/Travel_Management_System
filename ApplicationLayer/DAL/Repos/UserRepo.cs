using DAL.EF.Models;
using DAL.Interfaces;
using System.Linq;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IUserRepo<User, int>
    {
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
