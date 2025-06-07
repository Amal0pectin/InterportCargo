using System.ComponentModel.DataAnnotations;

namespace Interport_Amal.BusinessLogic.Entities
{
    public class RateSchedule
    {
        public int Id { get; set; }
        public string ChargeType { get; set; }
        public decimal Rate20Ft { get; set; }
        public decimal Rate40Ft { get; set; }
    }
}
