using BLL.Entity;
using IL.Interface.DAL;

namespace BLL.Container
{
    public class FlightScheduleContainer
    {
        private readonly IFlightScheduleDAL Db;

        public FlightScheduleContainer(IFlightScheduleDAL db) => Db = db;

        public FlightSchedule GetByName(string name) => new(Db.GetByName(name));

        public bool Insert(FlightSchedule flightSchedule) => Db.Insert(flightSchedule.GetDTO());
    }
}
