namespace DAL.Interfaces
{
    public interface IDestinationCountryCityRepo<CLASS, ID> : IRepo<CLASS, ID>
    {
        CLASS CheckCity(CLASS obj);
    }
}
