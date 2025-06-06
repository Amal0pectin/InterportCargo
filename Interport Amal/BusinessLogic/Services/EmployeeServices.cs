using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.BusinessLogic.Interfaces;
using Interport_Amal.DataAccess.Interfaces;

namespace Interport_Amal.BusinessLogic.Services
{
    public class EmployeeServices: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetAll() => _employeeRepository.GetAll();

        public Employee GetById(int EmployeeId) => _employeeRepository.GetById(EmployeeId);

        public Employee GetByEmail(string Email) => _employeeRepository.GetByEmail(Email);

        public void Add(Employee employee) => _employeeRepository.Add(employee);

        public void Update(Employee employee) => _employeeRepository.Update(employee);

        public void Delete(int EmployeeId) => _employeeRepository.Delete(EmployeeId);


    }
}
