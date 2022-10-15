using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class SpaceshipSTUB : ISpaceshipDAL
    {
        List<SpaceshipDTO> spaceships = new()
        {
            new(1, "Cosmic", 59000, 20, 1),
            new(2, "Saggitarius", 4895, 20, 2),
            new(3, "Vaccuum Star", 755, 25, 3),
            new(4, "Super nova", 320, 30, 4),
            new(5, "Quasor", 100, 35, 5),
            new(6, "Light Year", 30, 50, 6),
        };

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpaceshipDTO> GetAll()
        {
            return spaceships;
        }

        public SpaceshipDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SpaceshipDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SpaceshipDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
