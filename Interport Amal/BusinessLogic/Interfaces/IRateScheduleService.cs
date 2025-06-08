using Interport_Amal.BusinessLogic.Entities;

namespace Interport_Amal.BusinessLogic.Interfaces
{
    public interface IRateScheduleService
    {
        List<RateSchedule> GetAll();
        RateSchedule GetById(int id);
    }
}
