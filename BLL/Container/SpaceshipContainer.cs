using BLL.Entity;
using IL.Interface.DAL;

namespace BLL.Container
{
    public class SpaceshipContainer
    {
        private readonly ISpaceshipDAL db;

        public SpaceshipContainer(ISpaceshipDAL data)
        {
            db = data;
        }

        public List<Spaceship> GetAll()
        {
            List<Spaceship> list = new();
            db.GetAll().ToList().ForEach(spaceship => { list.Add(new(spaceship)); }); 
            return list;
        }
    }
}
