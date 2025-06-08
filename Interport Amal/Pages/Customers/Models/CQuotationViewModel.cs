namespace Interport_Amal.Pages.Customers.Models
{
    public class CQuotationViewModel
    {
    public int QuotationId { get; set; }
    public DateTime DateIssued { get; set; }
    public string ScopeDescription { get; set; }
    public decimal TotalCharge { get; set; }

    public string Source { get; set; }
    public string Destination { get; set; }
    public int ContainerCount { get; set; }
    public bool RequiresQuarantine { get; set; }
    public bool RequiresFumigation { get; set; }
    }
}
