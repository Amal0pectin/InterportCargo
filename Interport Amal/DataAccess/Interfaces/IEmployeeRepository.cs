using Interport_Amal.BusinessLogic.Entities;

namespace Interport_Amal.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {

        List<Employee> GetAll();
        Employee GetById(int EmployeeId);
        Employee GetByEmail(string Email);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int EmployeeId);
    }
}
