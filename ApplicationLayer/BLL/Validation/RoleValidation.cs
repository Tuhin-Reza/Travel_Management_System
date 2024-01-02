using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BLL.Validation
{
    public class RoleValidation : ValidationAttribute
    {
        public class RoleName : ValidationAttribute
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
                    ErrorMessage = "*Only letters and spaces are allowed";
                    return false;
                }

                return true;
            }
        }
    }
}
