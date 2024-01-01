using DAL.EF;

namespace DAL.Repos
{
    internal class Repo
    {
        protected TMSContext db;
        protected Repo()
        {
            db = new TMSContext();
        }
    }
}
