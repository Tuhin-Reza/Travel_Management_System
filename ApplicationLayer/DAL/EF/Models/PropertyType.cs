using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class PropertyType
    {
        public PropertyType()
        {
            this.Hotels = new HashSet<Hotel>();
        }

        [Key]
        public int PropertyTypeID { get; set; }
        [Required]
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }

        public ICollection<Hotel> Hotels { get; set; }
    }
}
