using Interport_Amal.Application.Interfaces;
using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.BusinessLogic.Interfaces;
using Interport_Amal.Pages.Customers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Interport_Amal.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {

        private readonly ICustomerService _customerService;

        public CustomerAppService(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task AddCustomerAsync(CustomerViewModel viewModel)
        {
            var passwordHasher = new PasswordHasher<Customer>();

            
            var customerEntity = new Customer
            {
                FirstName = viewModel.FirstName,
                FamilyName = viewModel.FamilyName,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Company = viewModel.Company,
                Address = viewModel.Address
            };

           
            customerEntity.PasswordHash = passwordHasher.HashPassword(customerEntity, viewModel.Password);

            _customerService.Add(customerEntity);
        }

        public async Task<Customer?> ValidateLoginAsync(CLoginViewModel login)
        {
            var customer = _customerService.GetByEmail(login.Email); 

            if (customer == null)
                return null;

            var hasher = new PasswordHasher<Customer>();
            var result = hasher.VerifyHashedPassword(customer, customer.PasswordHash, login.Password);

            return result == PasswordVerificationResult.Success ? customer : null;
        }

        public Task<bool> EmailExistsAsync(string email)
        {
            var customer = _customerService.GetByEmail(email);
            return Task.FromResult(customer != null);
        }

        public Customer GetCustomerID(int CustomerId) => _customerService.GetById(CustomerId);

        public void AddCustomer(Customer customer) => _customerService.Add(customer);

        public void UpdateCustomer(Customer customer) => _customerService.Update(customer);

        public void DeleteCustomer(int CustomerId) => _customerService.Delete(CustomerId);

        public List<Customer> GetAllCustomers() => _customerService.GetAll();

    }
}
