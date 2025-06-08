using System.ComponentModel.DataAnnotations;

namespace Interport_Amal.BusinessLogic.Entities
{
    public class QuotationRequest
    {
        public int Id { get; set; }
        public ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();

        public int CustomerId { get; set; }

        [Required]
        public string CustomerEmail { get; set; } = null!;

        public Customer? Customer { get; set; } = null!;

        [Required]
        public string Source { get; set; } = null!;

        public DateTime DateSubmitted { get; set; } = DateTime.Now;

        [Required]
        public string Destination { get; set; } = null!;

        [Required, Range(1, int.MaxValue)]
        public int ContainerCount { get; set; }

        [Required]
        public string PackageType { get; set; } = null!;

        [Required, Range(1, int.MaxValue)]
        public int Width { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Length { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Height { get; set; }

        [Required]
        public string NatureOfJob { get; set; } = null!;

        public bool RequiresQuarantine { get; set; }
        public bool RequiresFumigation { get; set; }

        public RequestStatus Status { get; set; } = RequestStatus.Pending;
    }

    public enum RequestStatus
    {
        Pending = 0,
        Accepted = 1,
        Rejected = 2
    }
}
