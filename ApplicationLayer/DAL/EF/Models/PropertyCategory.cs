using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class PropertyCategory
    {
        public PropertyCategory()
        {
            this.Properties = new HashSet<Property>();
            this.Hotels = new HashSet<Hotel>();
        }

        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string CategoryDescription { get; set; }

        public ICollection<Property> Properties { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}
