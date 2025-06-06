using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interport_Amal.BusinessLogic.Entities
{
    public class Customer
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

        public string Company { get; set; }

        public string Address { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}