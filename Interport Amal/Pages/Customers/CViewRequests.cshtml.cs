using Interport_Amal.Application.Interfaces;
using Interport_Amal.BusinessLogic.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Interport_Amal.Pages.Customers
{
    public class CViewRequestsModel : PageModel
    {
        private readonly IQuotationRequestAppService _quotationRequestAppService;

        public CViewRequestsModel(IQuotationRequestAppService quotationRequestAppService)
        {
            _quotationRequestAppService = quotationRequestAppService;
        }

        public List<QuotationRequest> CustomerRequests { get; set; }

        public IActionResult OnGet()
        {
            // Get the customer ID from the claims
            var customerIdClaim = User.FindFirst("CustomerId");
            if (customerIdClaim == null || !int.TryParse(customerIdClaim.Value, out int customerId))
            {
                return RedirectToPage("/Customers/CLogin");
            }

            // Get all requests, then filter by customer ID
            var allRequests = _quotationRequestAppService.GetAll();
            CustomerRequests = allRequests.Where(r => r.CustomerId == customerId).ToList();

            return Page();
        }
    }
}
