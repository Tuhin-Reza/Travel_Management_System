namespace BLL.DTOS
{
    public class RoomTypeDTO
    {
        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public int MemberCount { get; set; }
        public decimal Price { get; set; }
        public string RoomDescription { get; set; }
    }
}
