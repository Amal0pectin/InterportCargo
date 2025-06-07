using Interport_Amal.Application.Interfaces;
using Interport_Amal.Pages.Employee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Interport_Amal.Pages.Employee
{
    public class ELoginModel : PageModel
    {
        private readonly IEmployeeAppService _employeeAppService;

        public ELoginModel(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        [BindProperty]
        public ELoginViewModel Login { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var customer = await _employeeAppService.ValidateLoginAsync(Login);

            if (customer == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }


            return RedirectToPage("/Customers/EDashboard");
        }
    }
}
