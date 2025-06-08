using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Interport_Amal.Pages.Employee
{
    public class ELogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            await HttpContext.SignOutAsync();
            
            return RedirectToPage("/Employee/ELogin");
        }
    }
}
