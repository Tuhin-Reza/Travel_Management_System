namespace BLL.DTOS
{
    public class DestinationCountryCityPlaceDTO
    {
        public int PlaceID { get; set; }
        public string PlaceName { get; set; }
        public string PlaceDescription { get; set; }
        public int DestinationCountryID { get; set; }
        public int DestinationCountryCityID { get; set; }
    }
}
