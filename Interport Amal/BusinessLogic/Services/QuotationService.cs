using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.BusinessLogic.Interfaces;
using Interport_Amal.DataAccess.Interfaces;

namespace Interport_Amal.BusinessLogic.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly IQuotationRepository _quotationRepository;

        public QuotationService(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }

        public List<Quotation> GetAll() => _quotationRepository.GetAll();
        public Quotation GetById(int id) => _quotationRepository.GetById(id);
        public void Add(Quotation quotation) => _quotationRepository.Add(quotation);
        public void Update(Quotation quotation) => _quotationRepository.Update(quotation);
        public void Delete(int id) => _quotationRepository.Delete(id);
    }
}
