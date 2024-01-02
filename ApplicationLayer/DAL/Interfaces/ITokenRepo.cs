namespace DAL.Interfaces
{
    public interface ITokenRepo<Token, Id>
    {
        Token creted(Token obj);
        void update(Id id);
    }
}
