using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Interport_Amal.Pages.Employee.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string FamilyName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Phone { get; set; }
        public string Address { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string EmployeeType { get; set; }
        
    }
}
