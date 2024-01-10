namespace DAL.Interfaces
{
    public interface IAuth<CLASS>
    {
        CLASS Auth(CLASS obj);
    }

}
