using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IEmployeeRepo<Employee, ID>
    {
        Employee Create(Employee obj);
        Employee Get(ID id);
        List<Employee> GetAll();
        Employee Update(Employee obj);
        Employee Delete(ID id);

        List<Employee> GetByStatus(string status);
        void UpdateStatus(int id, string newStatus);
        Employee email(string eamil);
    }
}
