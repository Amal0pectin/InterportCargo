using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Interport_Amal.Application.Interfaces;
using Interport_Amal.Pages.Customers.Models;
using Interport_Amal.BusinessLogic.Entities;
using System.Security.Claims;

namespace Interport_Amal.Pages.Customers
{
    public class CNewRequestModel : PageModel
    {
        private readonly IQuotationRequestAppService _quotationRequestAppService;

        public CNewRequestModel(IQuotationRequestAppService quotationRequestAppService)
        {
            _quotationRequestAppService = quotationRequestAppService;
        }

        [BindProperty]
        public QuotationRequest QuotationRequest { get; set; }

        public void OnGet()
        {
            // Set email from claims
            var email = User.FindFirstValue(ClaimTypes.Email);
            QuotationRequest = new QuotationRequest
            {
                CustomerEmail = email
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState)
                {
                    foreach (var error in modelState.Value.Errors)
                    {
                        Console.WriteLine($"Error in {modelState.Key}: {error.ErrorMessage}");
                    }
                }

                TempData["Message"] = "Form has validation errors.";
                return Page();
            }

            var customerIdClaim = User.FindFirst("CustomerId")?.Value;
            if (!int.TryParse(customerIdClaim, out int customerId))
            {
                return Unauthorized();
            }

            QuotationRequest.CustomerId = customerId;
            QuotationRequest.DateSubmitted = DateTime.Now;

            _quotationRequestAppService.Add(QuotationRequest);

            TempData["Message"] = "Quotation request submitted successfully.";
            return RedirectToPage("/Customers/CDashboard");
        }
    }
}
