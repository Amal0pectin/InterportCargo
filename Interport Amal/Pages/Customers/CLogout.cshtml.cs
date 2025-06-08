using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Interport_Amal.Pages.Customers
{
    public class CLogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            // Sign out the user
            await HttpContext.SignOutAsync();

            // Redirect to login page (or home)
            return RedirectToPage("/Customers/CLogin");
        }
    }
}
