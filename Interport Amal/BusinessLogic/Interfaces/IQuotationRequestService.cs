using Interport_Amal.BusinessLogic.Entities;

namespace Interport_Amal.BusinessLogic.Interfaces
{
    public interface IQuotationRequestService
    {
        List<QuotationRequest> GetAll();
        QuotationRequest GetById(int id);
        void Add(QuotationRequest request);
        void Update(QuotationRequest request);
        void Delete(int id);
    }
}
