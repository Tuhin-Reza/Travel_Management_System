using static BLL.Validation.EmployeeTypeValidation;

namespace BLL.DTOS
{
    public class EmployeeTypeDTO
    {
        public int Id { get; set; }

        [TypeName]
        public string EmployeeTypeName { get; set; }

        [BasicSalary]
        public decimal BasicSalary { get; set; }


    }
}
