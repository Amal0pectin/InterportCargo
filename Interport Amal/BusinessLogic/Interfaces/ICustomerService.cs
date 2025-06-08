using Interport_Amal.BusinessLogic.Entities;

namespace Interport_Amal.BusinessLogic.Interfaces
{
    public interface ICustomerService
    {

        List<Customer> GetAll();
        Customer GetById(int CustomerId);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int CustomerId);
        Task<Customer?> GetByEmailAsync(string email);
    }
}