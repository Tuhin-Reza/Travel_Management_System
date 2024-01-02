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
    }
}
