using System;

namespace BLL.DTOS
{
    public class EmployeeSalaryDTO
    {
        public int Id { get; set; }
        public DateTime Month { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal DeductionSalaryLeave { get; set; }
        public decimal DeductionSalary { get; set; }
        public decimal TotalSalary { get; set; }
        public DateTime PublishDate { get; set; }
        public int EmployeeId { get; set; }
    }
}
