using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Interport_Amal.Application.Interfaces;
using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.Pages.Customers.Models;

namespace Interport_Amal.Pages.Customers
{
    public class CRegistrationModel : PageModel
    {
        private readonly ICustomerAppService _customerAppService;

        public CRegistrationModel(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [BindProperty]
        public CustomerViewModel Customer { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            if (await _customerAppService.EmailExistsAsync(Customer.Email))
            {
                ModelState.AddModelError("Customer.Email", "This email is already registered.");
                return Page();
            }

            await _customerAppService.AddCustomerAsync(Customer);

            return RedirectToPage("/Customers/CLogin");
        }
    }
}
