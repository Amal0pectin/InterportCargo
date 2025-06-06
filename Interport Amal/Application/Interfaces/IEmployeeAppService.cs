using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.Pages.Employee.Models;

namespace Interport_Amal.Application.Interfaces
{
    public interface IEmployeeAppService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeID(int EmployeeId);
        Task AddEmployeeAsync(EmployeeViewModel employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int EmployeeId);

        Task<Employee?> ValidateLoginAsync(ELoginViewModel login);
        Task<bool> EmailExistsAsync(string email);
    }
}
