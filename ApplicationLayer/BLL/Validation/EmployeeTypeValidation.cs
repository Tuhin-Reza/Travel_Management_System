using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BLL.Validation
{
    public class EmployeeTypeValidation : ValidationAttribute
    {
        public class TypeName : ValidationAttribute
        {
            public override bool IsValid(object value)
            {

                if (value == null)
                {
                    ErrorMessage = "*name required";
                    return false;
                }

                if (value.ToString().Length < 3)
                {
                    ErrorMessage = "*length minimum 3";
                    return false;
                }
                if (value is string strValue && !Regex.IsMatch(strValue, "^[a-zA-Z ]+$"))
                {
                    ErrorMessage = "*Only letters are allowed";
                    return false;
                }

                return true;
            }
        }

        public class BasicSalary : ValidationAttribute
        {
            private const decimal MinimumSalary = 500;

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value == null)
                {
                    return new ValidationResult("*Salary is required");
                }

                if (value is decimal salary)
                {
                    if (salary < MinimumSalary)
                    {
                        return new ValidationResult($"*Salary must be at least {MinimumSalary}");
                    }

                    return ValidationResult.Success;
                }

                return new ValidationResult("*Invalid salary format");
            }
        }

    }
}
