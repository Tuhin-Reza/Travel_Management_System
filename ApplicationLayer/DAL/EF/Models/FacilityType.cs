using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class FacilityType
    {
        public FacilityType()
        {
            this.Hotels = new HashSet<Hotel>();
        }

        [Key]
        public int FacilityID { get; set; }

        [Required]
        public string FacilityName { get; set; }
        public string FacilityDescription { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}
