using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<EmployeeType, int> EmployeeTypeData()
        {
            return new EmployeeTypeRepo();
        }

        public static IRepo<Role, int> RoleData()
        {
            return new RoleRepo();
        }
        public static IEmployeeRepo<Employee, int> EmployeeData()
        {
            return new EmployeeRepo();
        }

        public static IUserRepo<User, int> UserData()
        {
            return new UserRepo();
        }

    }
}
