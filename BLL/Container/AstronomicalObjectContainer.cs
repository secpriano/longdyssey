using BLL.Entity;
using IL.DTO;
using IL.Interface.DAL;

namespace BLL.Container
{
    public class AstronomicalObjectContainer
    {
        private readonly IAstronomicalObjectDAL Db;

        public AstronomicalObjectContainer(IAstronomicalObjectDAL db)
        {
            Db = db;
        }

        public List<AstronomicalObject> GetAll()
        {
            return Db.GetAll().Select(astronomicalObjectDTO => new AstronomicalObject(astronomicalObjectDTO)).ToList();
        }
    }
}
