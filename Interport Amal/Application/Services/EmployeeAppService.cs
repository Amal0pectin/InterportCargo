using Interport_Amal.Application.Interfaces;
using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.BusinessLogic.Interfaces;
using Interport_Amal.Pages.Employee.Models;
using Microsoft.AspNetCore.Identity;

namespace Interport_Amal.Application.Services
{
    public class EmployeeAppService : IEmployeeAppService
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeAppService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task AddEmployeeAsync(EmployeeViewModel viewModel)
        {
            var passwordHasher = new PasswordHasher<Employee>();


            var employeeEntity = new Employee
            {
                FirstName = viewModel.FirstName,
                FamilyName = viewModel.FamilyName,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                EmployeeType = viewModel.EmployeeType,
                Address = viewModel.Address
            };


            employeeEntity.PasswordHash = passwordHasher.HashPassword(employeeEntity, viewModel.Password);

            _employeeService.Add(employeeEntity);
        }

        public async Task<Employee?> ValidateLoginAsync(ELoginViewModel login)
        {
            var employee = _employeeService.GetByEmail(login.Email);

            if (employee == null)
                return null;

            var hasher = new PasswordHasher<Employee>();
            var result = hasher.VerifyHashedPassword(employee, employee.PasswordHash, login.Password);

            return result == PasswordVerificationResult.Success ? employee : null;
        }

        public Task<bool> EmailExistsAsync(string email)
        {
            var employee = _employeeService.GetByEmail(email);
            return Task.FromResult(employee != null);
        }

        public Employee GetEmployeeID(int EmployeeId) => _employeeService.GetById(EmployeeId);

        public void AddEmployee(Employee employee) => _employeeService.Add(employee);

        public void UpdateEmployee(Employee employee) => _employeeService.Update(employee);

        public void DeleteEmployee(int EmployeeId) => _employeeService.Delete(EmployeeId);

        public List<Employee> GetAllEmployees() => _employeeService.GetAll();

    }
}
