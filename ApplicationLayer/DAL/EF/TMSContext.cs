using DAL.EF.Models;
using System.Data.Entity;

namespace DAL.EF
{
    public class TMSContext : DbContext
    {
        //  public DbSet<Department> Departments { get; set; }
        public DbSet<TestTable> TestTables { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveSheet> LeaveSheets { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }

        public DbSet<DestinationCountry> DestinationCountries { get; set; }
        public DbSet<DestinationCountryCity> DestinationCountryCities { get; set; }
        public DbSet<DestinationCountryCityPlace> DestinationCountryCityPlaces { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<FacilityType> FacilityTypes { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyCategory> PropertyCategories { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DestinationCountryCityPlace>()
                .HasRequired(p => p.DestinationCountryCity)
                .WithMany()
                .HasForeignKey(p => p.DestinationCountryCityId)
                .WillCascadeOnDelete(false); // or true, depending on your requirements
        }

    }
}
