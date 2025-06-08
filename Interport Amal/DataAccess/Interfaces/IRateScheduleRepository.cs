using Interport_Amal.BusinessLogic.Entities;

namespace Interport_Amal.DataAccess.Interfaces
{
    public interface IRateScheduleRepository
    {
        List<RateSchedule> GetAll();
        RateSchedule GetById(int id);
    }
}
