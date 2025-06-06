using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Interport_Amal.Application.Interfaces;
using Interport_Amal.Pages.Customers.Models;
using Interport_Amal.BusinessLogic.Entities;



namespace Interport_Amal.Pages.Customers
{
    public class CLoginModel : PageModel
    {
        private readonly ICustomerAppService _customerAppService;

        public CLoginModel(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [BindProperty]
        public CLoginViewModel Login { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var customer = await _customerAppService.ValidateLoginAsync(Login);

            if (customer == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }


            return RedirectToPage("/Customers/CDashboard");
        }
    }
}
