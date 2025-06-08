using Interport_Amal.Application.Interfaces;
using Interport_Amal.Application.Services;
using Interport_Amal.BusinessLogic.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Interport_Amal.Pages.Customers
{
    public class CViewQuotationsModel : PageModel
    {
        private readonly IQuotationAppService _quotationAppService;

        public CViewQuotationsModel(IQuotationAppService quotationAppService)
        {
            _quotationAppService = quotationAppService;
        }

        public List<Quotation> Quotations { get; set; }

        public IActionResult OnGet()
        {
            int customerId = GetLoggedInCustomerId();

            Quotations = _quotationAppService
                .GetAllQuotations()
                .Where(q => q.CustomerId == customerId)
                .ToList();

            return Page();
        }

        private int GetLoggedInCustomerId()
        {
            var claim = User.FindFirst("CustomerId");
            return claim != null ? int.Parse(claim.Value) : 0;
        }
        public IActionResult OnPostAccept(int quotationId)
        {
            var quotation = _quotationAppService.GetQuotation(quotationId);
            if (quotation == null) return NotFound();

            quotation.Status = QuoteStatus.Accepted;
            _quotationAppService.UpdateQuotation(quotation);

            return RedirectToPage();
        }

        public IActionResult OnPostReject(int quotationId)
        {
            var quotation = _quotationAppService.GetQuotation(quotationId);
            if (quotation == null) return NotFound();

            quotation.Status = QuoteStatus.Rejected;
            _quotationAppService.UpdateQuotation(quotation);

            return RedirectToPage();
        }
    }
}