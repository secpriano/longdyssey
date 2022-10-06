using BLL.Entity;
using IL.Interface.DAL;

namespace BLL.Container
{
    public class SpaceshipContainer
    {
        ISpaceshipDAL Data;

        public SpaceshipContainer(ISpaceshipDAL data)
        {
            Data = data;
        }

        public List<Spaceship> GetAll()
        {
            List<Spaceship> list = new();
            Data.GetAll().ToList().ForEach(spaceship => { list.Add(new(spaceship)); }); 
            return list;
        }
    }
}
