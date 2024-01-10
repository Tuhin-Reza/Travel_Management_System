using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class DestinationCountryCityPlace
    {
        public DestinationCountryCityPlace()
        {
            this.Hotels = new HashSet<Hotel>();
        }

        [Key]
        public int PlaceID { get; set; }

        [Required]
        public string PlaceName { get; set; }

        public string PlaceDescription { get; set; }

        [ForeignKey("DestinationCountry")]
        public int DestinationCountryId { get; set; }
        public virtual DestinationCountry DestinationCountry { get; set; }

        [ForeignKey("DestinationCountryCity")]
        public int DestinationCountryCityId { get; set; }
        public virtual DestinationCountryCity DestinationCountryCity { get; set; }

        public ICollection<Hotel> Hotels { get; set; }

    }
}
