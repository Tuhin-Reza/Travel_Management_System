using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class RoomType
    {

        public RoomType()
        {
            this.Hotels = new HashSet<Hotel>();
        }

        [Key]
        public int RoomTypeID { get; set; }

        [Required]
        public string RoomTypeName { get; set; }
        public int MemberCount { get; set; }
        public decimal Price { get; set; }
        public string RoomDescription { get; set; }

        public ICollection<Hotel> Hotels { get; set; }
    }
}
