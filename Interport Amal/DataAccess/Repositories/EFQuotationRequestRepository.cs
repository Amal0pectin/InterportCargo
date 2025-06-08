using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.DataAccess.Data;
using Interport_Amal.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Interport_Amal.DataAccess.Repositories
{
    public class EFQuotationRequestRepository : IQuotationRequestRepository
    {
        private readonly CargoDBContext myContext;

        public EFQuotationRequestRepository (CargoDBContext context)
        {
            myContext = context;
        }
        public List<QuotationRequest> GetAll()
        {
            return myContext.QuotationRequests
                           .Include(q => q.Customer)
                           .ToList();
        }
        public async Task<List<QuotationRequest>> GetByCustomerEmailAsync(string email)
        {
            return await myContext.QuotationRequests
                .Where(q => q.CustomerEmail == email)
                .ToListAsync();
        }
        public QuotationRequest GetById(int id)
        {
            return myContext.QuotationRequests
                           .Include(q => q.Customer)
                           .FirstOrDefault(q => q.Id == id);
        }

        public void Add(QuotationRequest request)
        {
            myContext.QuotationRequests.Add(request);
            myContext.SaveChanges();
        }

        public void Update(QuotationRequest request)
        {
            myContext.QuotationRequests.Update(request);
            myContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var request = myContext.QuotationRequests.Find(id);
            if (request != null)
            {
                myContext.QuotationRequests.Remove(request);
                myContext.SaveChanges();
            }
        }

    }
}
