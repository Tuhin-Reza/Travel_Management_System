using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class DestinationCountryCity
    {
        public DestinationCountryCity()
        {
            this.DestinationCountryCityPlaces = new HashSet<DestinationCountryCityPlace>();
        }
        [Key]
        public int CityID { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public string CityDescription { get; set; }

        [Required]
        public int Population { get; set; }


        [ForeignKey("DestinationCountry")]
        public int DestinationCountryID { get; set; }
        public virtual DestinationCountry DestinationCountry { get; set; }

        public ICollection<DestinationCountryCityPlace> DestinationCountryCityPlaces { get; set; }
    }
}
