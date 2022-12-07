using BLL.Entity;
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
            List<AstronomicalObject> astronomicalObject = new();

            Db.GetAll().ForEach(astronomicalObjectDTO =>
            {
                astronomicalObject.Add(new(astronomicalObjectDTO));
            });

            return astronomicalObject;
        }
    }
}
