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

        public List<Spaceship> GetAll() => Db.GetAll().Select(spaceship => new Spaceship(spaceship)).ToList();
    }
}
