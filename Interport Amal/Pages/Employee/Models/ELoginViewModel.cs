using System.ComponentModel.DataAnnotations;

namespace Interport_Amal.Pages.Employee.Models
{
    public class ELoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
