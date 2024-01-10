using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class DestinationCountry
    {
        public DestinationCountry()
        {
            this.DestinationCountryCities = new HashSet<DestinationCountryCity>();
            this.DestinationCountryCitiesPlaces = new HashSet<DestinationCountryCityPlace>();
        }

        [Key]
        public int CountryID { get; set; }
        [Required]
        public string CountryName { get; set; }

        [Required]
        public int Population { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string Currency { get; set; }

        public ICollection<DestinationCountryCity> DestinationCountryCities { get; set; }
        public ICollection<DestinationCountryCityPlace> DestinationCountryCitiesPlaces { get; set; }
    }
}
