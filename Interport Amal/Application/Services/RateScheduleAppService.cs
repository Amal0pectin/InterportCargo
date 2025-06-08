using Interport_Amal.Application.Interfaces;
using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.BusinessLogic.Interfaces;

namespace Interport_Amal.Application.Services
{
    public class RateScheduleAppService : IRateScheduleAppService
    {
        private readonly IRateScheduleService _rateScheduleService;

        public RateScheduleAppService(IRateScheduleService rateScheduleService)
        {
            _rateScheduleService = rateScheduleService;
        }

        public List<RateSchedule> GetAll() => _rateScheduleService.GetAll();

        public RateSchedule GetById(int id) => _rateScheduleService.GetById(id);
    }
}
