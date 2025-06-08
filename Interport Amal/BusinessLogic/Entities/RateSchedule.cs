using System.ComponentModel.DataAnnotations;

namespace Interport_Amal.BusinessLogic.Entities
{
    public class RateSchedule
    {
        public int Id { get; set; }
        public string ChargeType { get; set; }
        public double Rate20Ft { get; set; }
        public double Rate40Ft { get; set; }
    }
}
