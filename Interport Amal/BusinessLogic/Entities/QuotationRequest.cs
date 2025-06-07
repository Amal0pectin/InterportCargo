using System.ComponentModel.DataAnnotations;

namespace Interport_Amal.BusinessLogic.Entities
{
    public class QuotationRequest
    {
        public int Id { get; set; }
        public ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public string Source { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public int NumberOfContainers { get; set; }
        public string GoodsType { get; set; } = null!;
        public double Width { get; set; }
        public double Height { get; set; }

        public string NatureOfJob { get; set; } = null!;
        public bool RequiresQuarantine { get; set; }
        public bool RequiresFumigation { get; set; }

        public List<Quotation> Quotation { get; set; } = new();
    }
}
