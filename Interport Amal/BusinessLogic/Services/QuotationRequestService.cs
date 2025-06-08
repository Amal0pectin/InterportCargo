using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.BusinessLogic.Interfaces;
using Interport_Amal.DataAccess.Interfaces;

namespace Interport_Amal.BusinessLogic.Services
{
    public class QuotationRequestService : IQuotationRequestService
    {
        private readonly IQuotationRequestRepository _quotationRequestRepository;

        public QuotationRequestService(IQuotationRequestRepository quotationRequestRepository)
        {
            _quotationRequestRepository = quotationRequestRepository;
        }
        public async Task<List<QuotationRequest>> GetByCustomerEmailAsync(string email)
        {
            return await _quotationRequestRepository.GetByCustomerEmailAsync(email);
        }

        public List<QuotationRequest> GetAll() => _quotationRequestRepository.GetAll();

        public QuotationRequest GetById(int id) => _quotationRequestRepository.GetById(id);

        public void Add(QuotationRequest request) => _quotationRequestRepository.Add(request);

        public void Update(QuotationRequest request) => _quotationRequestRepository.Update(request);

        public void Delete(int id) => _quotationRequestRepository.Delete(id);
    }
}
