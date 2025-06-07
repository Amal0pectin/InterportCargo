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
            quotation.TotalCharge = await CalculateTotalChargeAsync(quotation);
            _quotationService.Add(quotation);
        }

        public Task<decimal> CalculateTotalChargeAsync(Quotation quotation)
        {
            if (quotation.Items == null || !quotation.Items.Any())
                return Task.FromResult(0m);

            decimal baseTotal = quotation.Items.Sum(item =>
            {
                return item.ContainerType == "20 Feet Container"
                    ? item.RateSchedule?.Rate20Ft ?? 0
                    : item.RateSchedule?.Rate40Ft ?? 0;
            });

            int count = quotation.Items.Count;
            bool quarantine = quotation.QuotationRequest?.RequiresQuarantine == true;
            bool fumigation = quotation.QuotationRequest?.RequiresFumigation == true;

            decimal surcharge = 0m;

            if (count > 10 && quarantine && fumigation)
                surcharge = 0.10m;
            else if (count > 5 && quarantine && fumigation)
                surcharge = 0.05m;
            else if (count > 5 && (quarantine || fumigation))
                surcharge = 0.025m;

            decimal total = baseTotal * (1 + surcharge);
            return Task.FromResult(total);
        }
    }
}
