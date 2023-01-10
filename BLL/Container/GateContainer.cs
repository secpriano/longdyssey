using BLL.Entity;
using IL.Interface.DAL;

namespace BLL.Container
{
    public class GateContainer
    {
        private readonly IGateDAL Db;

        public GateContainer(IGateDAL db) => Db = db;

        public Gate GetByAstronomicalObjectName(string name) => new(Db.GetByAstronomicalObjectName(name));
    }
}
