using BLL.Entity;
using IL.Interface.DAL;

namespace BLL.Container
{
    public class SpaceshipContainer
    {
        private readonly ISpaceshipDAL Db;

        public SpaceshipContainer(ISpaceshipDAL db)
        {
            Db = db;
        }

        public List<Spaceship> GetAll()
        {
            List<Spaceship> list = new();
            Db.GetAll().ToList().ForEach(spaceship => { list.Add(new(spaceship)); }); 
            return list;
        }
    }
}
