using Interport_Amal.BusinessLogic.Entities;

namespace Interport_Amal.BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Employee GetById(int EmployeeId);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int EmployeeId);
        Employee GetByEmail(string email);
    }
}
