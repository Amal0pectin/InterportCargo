using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.BusinessLogic.Interfaces;
using Interport_Amal.DataAccess.Interfaces;

namespace Interport_Amal.BusinessLogic.Services
{
    public class CustomerServices : ICustomerService
    {
         private readonly ICustomerRepository _customerRepository;

    public CustomerServices(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public List<Customer> GetAll() => _customerRepository.GetAll();

    public Customer GetById(int CustomerId) => _customerRepository.GetById(CustomerId);

    public Customer GetByEmail (string Email) => _customerRepository.GetByEmail(Email);

    public void Add(Customer customer) => _customerRepository.Add(customer);

    public void Update(Customer customer) => _customerRepository.Update(customer);

    public void Delete(int CustomerId) => _customerRepository.Delete(CustomerId);

    
    }
}
