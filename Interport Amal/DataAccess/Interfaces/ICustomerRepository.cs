using Interport_Amal.BusinessLogic.Entities;

namespace Interport_Amal.DataAccess.Interfaces
{
    public interface ICustomerRepository
    {

        List<Customer> GetAll();
        Customer GetById(int CustomerId);
        Customer GetByEmail(string Email);
        void Add(Customer customer);
        void Update(Customer Customer);
        void Delete(int CustomerId);

    }
}
