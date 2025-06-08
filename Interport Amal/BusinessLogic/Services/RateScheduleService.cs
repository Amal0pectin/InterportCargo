using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.BusinessLogic.Interfaces;
using Interport_Amal.DataAccess.Interfaces;


namespace Interport_Amal.BusinessLogic.Services
{
    public class RateScheduleService : IRateScheduleService
    {
        private readonly IRateScheduleRepository _rateScheduleRepository;

        public RateScheduleService(IRateScheduleRepository rateScheduleRepository)
        {
            _rateScheduleRepository = rateScheduleRepository;
        }

        public List<RateSchedule> GetAll() => _rateScheduleRepository.GetAll();

        public RateSchedule GetById(int id) => _rateScheduleRepository.GetById(id);
    }
}
