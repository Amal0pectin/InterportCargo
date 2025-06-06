using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Interport_Amal.BusinessLogic.Entities;

using Interport_Amal.Application.Interfaces;
using Interport_Amal.Pages.Employee.Models;

namespace Interport_Amal.Pages.Employee
{
    public class ERegistrationModel : PageModel
    {
        private readonly IEmployeeAppService _employeeAppService;

        public ERegistrationModel(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        [BindProperty]
        public EmployeeViewModel Employee { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            if (await _employeeAppService.EmailExistsAsync(Employee.Email))
            {
                ModelState.AddModelError("Employee.Email", "This email is already registered.");
                return Page();
            }

            await _employeeAppService.AddEmployeeAsync(Employee);

            return RedirectToPage("/Employee/ELogin");
        }
    }
}
