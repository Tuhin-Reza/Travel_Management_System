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

        public static IRepo<FacilityType, int> FacilityTypeData()
        {
            return new FacilityTypeRepo();
        }

        public static IRepo<PropertyType, int> PropertyTypeData()
        {
            return new PropertyTypeRepo();
        }

        public static IRepo<PropertyCategory, int> PropertyCategoryData()
        {
            return new PropertyCategoryRepo();
        }

        public static IRepo<DestinationCountry, int> DestinationCountryData()
        {
            return new DestinationCountryRepo();
        }

        public static IDestinationCountryCityRepo<DestinationCountryCity, int> DestinationCountryCityData()
        {
            return new DestinationCountryCityRepo();
        }

        public static IDestinationCountryCityPlacesRepo<DestinationCountryCityPlace, int> DestinationCountryCityPlaceData()
        {
            return new DestinationCountryCityPlaceRepo();
        }


        public static IRepo<RoomType, int> RoomTypeData()
        {
            return new RoomTypeRepo();
        }

        public static IRepo<Hotel, int> HotelData()
        {
            return new HotelRepo();
        }

        public static IRepo<LeaveType, int> LeaveTypeData()
        {
            return new LeaveTypeRepo();
        }

        public static IRepo<LeaveRequest, int> LeaveRequestData()
        {
            return new LeaveRequestRepo();
        }

        public static IRepo<LeaveSheet, int> LeaveSheetData()
        {
            return new LeaveSheetRepo();
        }

        public static IRepo<EmployeeSalary, int> EmployeeSalaryData()
        {
            return new EmployeeSalaryRepo();
        }

        public static IAuth<User> UserLoginData()
        {
            return new UserRepo();
        }

        public static IRepo<Token, int> TokenData()
        {
            return new TokenRepo();
        }






    }
}
