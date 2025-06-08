using Interport_Amal.BusinessLogic.Entities;

namespace Interport_Amal.DataAccess.Interfaces
{
    public interface IQuotationRequestRepository
    {
        List<QuotationRequest> GetAll();
        Task<List<QuotationRequest>> GetByCustomerEmailAsync(string email);
        QuotationRequest GetById(int id);
        void Add(QuotationRequest request);
        void Update(QuotationRequest request);
        void Delete(int id);
    }
}
