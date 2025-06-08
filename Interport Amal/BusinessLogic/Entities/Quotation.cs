using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interport_Amal.BusinessLogic.Entities
{
    public class Quotation
    {
        public int Id { get; set; }

        [Required]
        public int QuotationRequestId { get; set; }
        public QuotationRequest QuotationRequest { get; set; }

        [Required]
        public DateTime DateIssued { get; set; }

        [Required]
        public string ScopeDescription { get; set; } = null!;

        // Foreign key to Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public List<QuotationItem> Items { get; set; } = new();

        public decimal TotalCharge { get; set; }
    }
    public class QuotationItem
    {
        public int Id { get; set; }

        public int QuotationId { get; set; }
        public Quotation Quotation { get; set; }

        public int RateScheduleId { get; set; }
        public RateSchedule RateSchedule { get; set; }

        [Required]
        public string ContainerType { get; set; } // "20 Feet Container" or "40 Feet Container"

        public QuoteStatus Status { get; set; } = QuoteStatus.Pending;

        public decimal GetCharge()
        {
            return ContainerType == "20 Feet Container"
                ? RateSchedule.Rate20Ft
                : RateSchedule.Rate40Ft;
        }
        public enum QuoteStatus
        {
            Pending = 0,
            Accepted = 1,
            Rejected = 2
        }
    }
}

  