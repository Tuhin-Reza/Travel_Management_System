using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class Property
    {
        [Key]
        public int PropertyID { get; set; }

        //[Required]
        //public string PropertyAddress { get; set; }

        //[ForeignKey("DestinationCountryCityPlace")]
        //public int DestinationCountryCityPlaceID { get; set; }

        //[ForeignKey("PropertyCategory")]
        //public int PropertyCategoryID { get; set; }

        //[ForeignKey("PropertyType")]
        //public int PropertyTypeID { get; set; }


        //public PropertyType PropertyType { get; set; }
        //public PropertyCategory PropertyCategory { get; set; }
        //public DestinationCountryCityPlace DestinationCountryCityPlace { get; set; }
    }
}
