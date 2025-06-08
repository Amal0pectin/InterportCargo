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

        public async Task CreateQuotationAsync(Quotation quotation)
        {
            var (total, discountPercent) = await CalculateTotalWithDiscount(quotation);
            quotation.TotalCharge = total;
        }

        public Task<(decimal total, decimal discountPercent)> CalculateTotalWithDiscount(Quotation quotation)
        {
            if (quotation.Items == null || !quotation.Items.Any())
                return Task.FromResult((0m, 0m));

            decimal baseTotal = quotation.Items.Sum(item =>
            {
                return item.ContainerType == "20 Feet Container"
                    ? item.RateSchedule?.Rate20Ft ?? 0
                    : item.RateSchedule?.Rate40Ft ?? 0;
            });

            int containerCount = quotation.QuotationRequest?.ContainerCount ?? 0;
            bool quarantine = quotation.QuotationRequest?.RequiresQuarantine == true;
            bool fumigation = quotation.QuotationRequest?.RequiresFumigation == true;

            decimal discount = 0m;

            if (containerCount > 10 && quarantine && fumigation)
                discount = 0.10m;
            else if (containerCount > 5 && quarantine && fumigation)
                discount = 0.05m;
            else if (containerCount > 5 && (quarantine || fumigation))
                discount = 0.025m;

            decimal total = baseTotal * (1 - discount);
            return Task.FromResult((total, discount * 100));
        }
    }
}
