using Interport_Amal.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using  Interport_Amal.DataAccess.Data;
using  Interport_Amal.BusinessLogic.Entities;
using System.Collections.Generic;

namespace  Interport_Amal.DataAccess.Repositories
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly CargoDBContext myContext;

        public EFCustomerRepository(CargoDBContext context)
        {
            myContext = context;
        }


        public List<Customer> GetAll() => myContext.Customers.ToList();

        public Customer GetById(int CustomerId) => myContext.Customers.Find(CustomerId);

        public Customer GetByEmail(string email)
        {
            return myContext.Customers.FirstOrDefault(c => c.Email == email);
        }

        public void Add(Customer customer)
        {
            myContext.Customers.Add(customer);
            myContext.SaveChanges();
        }

        public void Update(Customer customer)
        {
            myContext.Entry(customer).State = EntityState.Modified;
            myContext.SaveChanges();
        }

        public void Delete(int CustomerId)
        {
            var customer = myContext.Customers.Find(CustomerId);
            if (customer != null)
            {
                myContext.Customers.Remove(customer);
                myContext.SaveChanges();
            }
        }

    }
}