namespace DAL.Interfaces
{
    public interface IUserRepo<User, ID>
    {
        void create(User user);
        void UpdatePassword(ID id, string newPassword);
    }
}
