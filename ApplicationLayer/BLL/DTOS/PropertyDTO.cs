namespace BLL.DTOS
{
    public class PropertyDTO
    {
        public int PropertyID { get; set; }
        public string PropertyAddress { get; set; }
        public int DestinationCountryCityPlaceID { get; set; }
        public int PropertyCategoryID { get; set; }
        public int PropertyTypeID { get; set; }

    }
}
