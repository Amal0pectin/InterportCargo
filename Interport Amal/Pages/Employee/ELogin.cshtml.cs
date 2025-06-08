using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Interport_Amal.Application.Interfaces;
using Interport_Amal.Pages.Employee.Models;
using Interport_Amal.BusinessLogic.Entities;



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

            var employee = await _employeeAppService.ValidateLoginAsync(Login);

            if (employee == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }


            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, employee.FirstName),
        new Claim(ClaimTypes.Email, employee.Email),
        new Claim("EmployeeId", employee.Id.ToString())
    };


            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return RedirectToPage("/Employee/EDashboard");
        }
    }
}
