using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS, ID>
    {
        CLASS Create(CLASS obj);
        CLASS Get(ID id);
        List<CLASS> GetAll();
        CLASS Update(CLASS obj);
        CLASS Delete(ID id);
        CLASS Name(string employeeTypeName);

    }
}
