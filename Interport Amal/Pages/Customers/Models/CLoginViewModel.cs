using System.ComponentModel.DataAnnotations;

namespace Interport_Amal.Pages.Customers.Models
{
    public class CLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
