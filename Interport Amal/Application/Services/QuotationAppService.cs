using Interport_Amal.Application.Interfaces;
using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.BusinessLogic.Interfaces;

namespace Interport_Amal.Application.Services
{
    public class QuotationAppService : IQuotationAppService
    {
        private readonly IQuotationService _quotationService;

        public QuotationAppService(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }

        public List<Quotation> GetAllQuotations() => _quotationService.GetAll();
        public Quotation GetQuotation(int id) => _quotationService.GetById(id);
        public List<Quotation> GetQuotationsByCustomerId(int customerId)
        {
            return _quotationService.GetAll()
                .Where(q => q.CustomerId == customerId)
                .ToList();
        }

        public async Task CreateQuotationAsync(Quotation quotation)
        {
            var (total, discountPercent) = await CalculateTotalWithDiscount(quotation);
            quotation.TotalCharge = total;
        }

        public Task<(double total, double discountPercent)> CalculateTotalWithDiscount(Quotation quotation)
        {
            if (quotation.Items == null || !quotation.Items.Any())
                return Task.FromResult((0d, 0d));

            double baseTotal = quotation.Items.Sum(item =>
            {
                return item.ContainerType == "20 Feet Container"
                    ? item.RateSchedule?.Rate20Ft ?? 0
                    : item.RateSchedule?.Rate40Ft ?? 0;
            });

            int containerCount = quotation.QuotationRequest?.ContainerCount ?? 0;
            bool quarantine = quotation.QuotationRequest?.RequiresQuarantine == true;
            bool fumigation = quotation.QuotationRequest?.RequiresFumigation == true;

            double discount = 0d;

            if (containerCount > 10 && quarantine && fumigation)
                discount = 0.10d;
            else if (containerCount > 5 && quarantine && fumigation)
                discount = 0.05d;
            else if (containerCount > 5 && (quarantine || fumigation))
                discount = 0.025d;

            double total = baseTotal * (1 - discount);
            return Task.FromResult((total, discount * 100));
        }
        public void UpdateQuotation(Quotation quotation)
        {
            _quotationService.Update(quotation);
        }
    }
}
