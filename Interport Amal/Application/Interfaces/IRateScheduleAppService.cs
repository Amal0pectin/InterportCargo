using Interport_Amal.BusinessLogic.Entities;

namespace Interport_Amal.Application.Interfaces
{
    public interface IRateScheduleAppService
    {
        List<RateSchedule> GetAll();
        RateSchedule GetById(int id);
    }
}
