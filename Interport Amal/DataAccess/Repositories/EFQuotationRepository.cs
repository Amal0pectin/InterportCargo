using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.DataAccess.Data;
using Interport_Amal.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Interport_Amal.DataAccess.Repositories
{
    public class EFQuotationRepository : IQuotationRepository
    {
        private readonly CargoDBContext myContext;

        public EFQuotationRepository(CargoDBContext context)
        {
            myContext = context;
        }

        public List<Quotation> GetAll()
        {
            return myContext.Quotations
                .Include(q => q.Items)
                .Include(q => q.QuotationRequest)
                .ToList();
        }
        public Quotation GetById(int QuotationId)
        {
            return myContext.Quotations
                           .Include(q => q.Customer)
                           .Include(q => q.Items)
                           .ThenInclude(i => i.RateSchedule)
                           .FirstOrDefault(q => q.Id == QuotationId);
        }

        public void Add(Quotation quotation)
        {
            myContext.Quotations.Add(quotation);
            myContext.SaveChanges();
        }

        public void Update(Quotation quotation)
        {
            myContext.Quotations.Update(quotation);
            myContext.SaveChanges();
        }

        public void Delete(int quotationId)
        {
            var quotation = myContext.Quotations.Find(quotationId);
            if (quotation != null)
            {
                myContext.Quotations.Remove(quotation);
                myContext.SaveChanges();
            }
        }
    }
}
