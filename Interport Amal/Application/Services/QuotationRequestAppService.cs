using Interport_Amal.Application.Interfaces;
using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.BusinessLogic.Interfaces;

namespace Interport_Amal.Application.Services
{
    public class QuotationRequestAppService : IQuotationRequestAppService
    {
        private readonly IQuotationRequestService _quotationRequestService;

        public QuotationRequestAppService(IQuotationRequestService quotationRequestService)
        {
            _quotationRequestService = quotationRequestService;
        }

        public List<QuotationRequest> GetAll()
        {
            return _quotationRequestService.GetAll();
        }

        public QuotationRequest GetById(int id)
        {
            return _quotationRequestService.GetById(id);
        }

        public void Add(QuotationRequest request)
        {
            _quotationRequestService.Add(request);
        }

        public void Update(QuotationRequest request)
        {
            _quotationRequestService.Update(request);
        }

        public void Delete(int id)
        {
            _quotationRequestService.Delete(id);
        }
        public async Task<List<QuotationRequest>> GetByCustomerEmailAsync(string email)
        {
            return await _quotationRequestService.GetByCustomerEmailAsync(email);
        }
    }
}
