using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.DataAccess.Data;
using Interport_Amal.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Interport_Amal.DataAccess.Repositories
{
    public class RateScheduleRepository : IRateScheduleRepository
    {
        private readonly CargoDBContext myContext;

        public RateScheduleRepository(CargoDBContext context)
        {
            myContext = context;
        }

        public List<RateSchedule> GetAll()
        {
            return myContext.RateSchedule.ToList();
        }

        public RateSchedule GetById(int id)
        {
            return myContext.RateSchedule.FirstOrDefault(r => r.Id == id);
        }
    }
}
