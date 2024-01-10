using DAL.EF.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, int>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public Token Get(int id)
        {
            return db.Tokens.Find(id);
        }

        public List<Token> GetAll()
        {
            return db.Tokens.ToList();
        }

        public Token Update(Token obj)
        {
            var ex = Get(obj.Id);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            return null;
        }

        public Token Delete(int id)
        {
            var ex = Get(id);
            if (ex != null)
            {
                db.Tokens.Remove(ex);
                db.SaveChanges();
                return ex;
            }
            return null;
        }
        public Token Name(string Name)
        {
            return null;
        }
    }
}
