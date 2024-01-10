using System.Collections.Generic;

namespace BLL.DTOS
{
    public class PropertyTypePropertyDTO
    {
        public List<PropertyDTO> Properties { get; set; }
        public PropertyTypePropertyDTO()
        {
            Properties = new List<PropertyDTO>();
        }
    }
}
