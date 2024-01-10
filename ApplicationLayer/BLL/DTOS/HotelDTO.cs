namespace BLL.DTOS
{
    public class HotelDTO
    {
        public int HotelID { get; set; }
        public string HotelName { get; set; }
        public int PropertyTypeID { get; set; }
        public int PropertyCategoryID { get; set; }
        public int FacilityTypeID { get; set; }
        public int CityPlaceID { get; set; }
        public int RoomTypeID { get; set; }
        public int TotalRoom { get; set; }
        public string RoomStatus { get; set; }
    }
}
