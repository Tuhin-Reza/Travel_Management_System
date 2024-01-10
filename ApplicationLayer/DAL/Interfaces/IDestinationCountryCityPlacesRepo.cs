namespace DAL.Interfaces
{
    public interface IDestinationCountryCityPlacesRepo<CLASS, ID> : IRepo<CLASS, ID>
    {
        CLASS CheckCityPlace(CLASS obj);
    }
}
