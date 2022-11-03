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
            List<Spaceship> spaceships = new();
            Db.GetAll().ToList().ForEach(spaceship => { spaceships.Add(new(spaceship)); });

            return spaceships;
        }
    }
}
