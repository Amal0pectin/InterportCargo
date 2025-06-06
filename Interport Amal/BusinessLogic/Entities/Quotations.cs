using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interport_Amal.BusinessLogic.Entities
{
    public class Quotation
    {
        public int Id { get; set; }

        [Required]
        public string QuotationNumber { get; set; } = null!;

        [Required]
        public DateTime DateIssued { get; set; }

        [Required]
        public string ContainerType { get; set; } = null!;

        [Required]
        public string ScopeDescription { get; set; } = null!;

        // Foreign key to Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        // One-to-many relationship to QuotationItems
        public List<QuotationItem> Items { get; set; } = new();

        public decimal TotalCharge { get; set; }
    }

    public class QuotationItem
    {
        public int Id { get; set; }

        public int QuotationId { get; set; }
        public Quotation Quotation { get; set; } = null!;

        public int RateScheduleId { get; set; }
        public RateSchedule RateSchedule { get; set; } = null!;
    }
}