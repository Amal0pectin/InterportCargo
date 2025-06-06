using System.ComponentModel.DataAnnotations;

namespace Interport_Amal.BusinessLogic.Entities
{
    public class RateSchedule
    {
        public int Id { get; set; }

        [Required]
        public string ServiceType { get; set; } = null!; // e.g. "Fumigation"

        [Required]
        public string ContainerType { get; set; } = null!; // e.g. "20 Feet Container"

        [Required]
        public decimal Rate { get; set; }
        public List<QuotationItem> QuotationItems { get; set; } = new();
    }
}
