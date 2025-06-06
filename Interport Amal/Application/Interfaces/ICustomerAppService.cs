using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.Pages.Customers.Models;

namespace Interport_Amal.Application.Interfaces
{
    public interface ICustomerAppService
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerID(int CustomerId);
        Task AddCustomerAsync(CustomerViewModel customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int CustomerId);

        Task<Customer?> ValidateLoginAsync(CLoginViewModel login);
        Task<bool> EmailExistsAsync(string email);
    }
}