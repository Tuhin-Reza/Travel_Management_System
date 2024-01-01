using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class EmployeeType
    {
        public EmployeeType()
        {
            this.Employees = new HashSet<Employee>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmployeeTypeName { get; set; }

        [Required]
        public decimal BasicSalary { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
