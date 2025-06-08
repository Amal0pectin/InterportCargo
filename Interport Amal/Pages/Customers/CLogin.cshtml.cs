using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

            
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, customer.FirstName), 
        new Claim(ClaimTypes.Email, customer.Email),
        new Claim("CustomerId", customer.Id.ToString()) 
    };

            
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return RedirectToPage("/Customers/CDashboard");
        }
    }
}
