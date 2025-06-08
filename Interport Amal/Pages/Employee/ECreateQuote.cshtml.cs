using Interport_Amal.Application.Interfaces;
using Interport_Amal.BusinessLogic.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Interport_Amal.Pages.Employee
{
    public class ECreateQuoteModel : PageModel
    {
        private readonly IQuotationAppService _quotationAppService;
        private readonly IQuotationRequestAppService _quotationRequestAppService;
        private readonly IRateScheduleAppService _rateScheduleAppService;

        public ECreateQuoteModel(
            IQuotationAppService quotationAppService,
            IQuotationRequestAppService quotationRequestAppService,
            IRateScheduleAppService rateScheduleAppService)
        {
            _quotationAppService = quotationAppService;
            _quotationRequestAppService = quotationRequestAppService;
            _rateScheduleAppService = rateScheduleAppService;
        }

        [BindProperty]
        public Quotation Quotation { get; set; } = new Quotation();

      
        public List<RateSchedule> RateSchedules { get; set; } = new List<RateSchedule>();
        
        
        public double TotalCharge { get; set; }

        
        public double DiscountPercent { get; set; }

        public IActionResult OnGet(int requestId)
        {
            var request = _quotationRequestAppService.GetById(requestId);
            if (request == null)
                return NotFound();

            Quotation.QuotationRequestId = request.Id;
            Quotation.QuotationRequest = request;
            Quotation.CustomerId = request.CustomerId;
            Quotation.DateIssued = DateTime.Now;
            Quotation.ScopeDescription = $"Quote for moving from {request.Source} to {request.Destination}";

            for (int i = 0; i < request.ContainerCount; i++)
            {
                Quotation.Items.Add(new QuotationItem());
            }

            RateSchedules = _rateScheduleAppService.GetAll();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string action)
        {
            RateSchedules = _rateScheduleAppService.GetAll();

            // Re-fetch QuotationRequest
            Quotation.QuotationRequest = _quotationRequestAppService.GetById(Quotation.QuotationRequestId);

            if (action == "calculate")
            {
                var (total, discount) = await _quotationAppService.CalculateTotalWithDiscount(Quotation);
                TotalCharge = total;
                DiscountPercent = discount;
                return Page();
            }

            if (action == "submit")
            {
                await _quotationAppService.CreateQuotationAsync(Quotation);
                return RedirectToPage("/Employee/EDashboard");
            }

            return Page();
        }
    }
}