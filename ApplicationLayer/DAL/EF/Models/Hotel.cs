using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class Hotel
    {


        [Key]
        public int HotelID { get; set; }
        [Required]
        public string HotelName { get; set; }


        [ForeignKey("PropertyType")]
        public int PropertyTypeID { get; set; }
        public virtual PropertyType PropertyType { get; set; }

        [ForeignKey("PropertyCategory")]
        public int PropertyCategoryID { get; set; }
        public virtual PropertyCategory PropertyCategory { get; set; }

        [ForeignKey("FacilityType")]
        public int FacilityTypeID { get; set; }
        public virtual FacilityType FacilityType { get; set; }


        [ForeignKey("DestinationCountryCityPlace")]
        public int CityPlaceID { get; set; }
        public virtual DestinationCountryCityPlace DestinationCountryCityPlace { get; set; }

        [ForeignKey("RoomType")]
        public int RoomTypeID { get; set; }
        public virtual RoomType RoomType { get; set; }

        public int TotalRoom { get; set; }
        public string RoomStatus { get; set; }
    }
}
