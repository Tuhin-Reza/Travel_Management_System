using System.Collections.Generic;

namespace BLL.DTOS
{
    public class RoleUserDTO : RoleDTO
    {
        public List<UserDTO> Users { get; set; }
        public RoleUserDTO()
        {
            Users = new List<UserDTO>();
        }
    }
}
