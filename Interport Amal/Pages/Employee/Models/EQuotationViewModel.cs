using Microsoft.AspNetCore.Mvc.Rendering;

namespace Interport_Amal.Pages.Employee.Models
{
    public class EQuotationItemViewModel
    {
        public string ContainerType { get; set; } = "20 Feet Container";
        public int SelectedRateScheduleId { get; set; }
        public List<SelectListItem> AvailableRateSchedules { get; set; } = new();
    }
    public class ECreateQuoteViewModel
    {
        public int QuotationRequestId { get; set; }
        public decimal TotalCharge { get; set; }
        public decimal DiscountPercent { get; set; }
        public List<EQuotationItemViewModel> Items { get; set; } = new();
    }
}
