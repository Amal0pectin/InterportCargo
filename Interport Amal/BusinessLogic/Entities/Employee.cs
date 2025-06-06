using System.ComponentModel.DataAnnotations;
namespace Interport_Amal.BusinessLogic.Entities
{
    public class Employee
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
        public string PasswordHash { get; set; }

        [Required]
        public string EmployeeType  { get; set; }
     
    }
}
