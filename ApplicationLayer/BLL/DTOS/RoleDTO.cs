using static BLL.Validation.RoleValidation;

namespace BLL.DTOS
{
    public class RoleDTO
    {
        public int Id { get; set; }
        [RoleName]
        public string RoleName { get; set; }
    }
}
