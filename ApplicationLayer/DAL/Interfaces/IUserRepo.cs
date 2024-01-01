namespace DAL.Interfaces
{
    public interface IUserRepo<User, ID>
    {
        void UpdatePassword(ID id, string newPassword);
    }
}
