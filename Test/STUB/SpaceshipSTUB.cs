using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class SpaceshipSTUB : ISpaceshipDAL
    {
        public List<SpaceshipDTO> spaceships = new()
        {
            new(1, "Cosmic", 59000, 0.1M, 1),
            new(2, "Saggitarius", 4895, 0.2M, 2),
            new(3, "Vaccuum Star", 755, 0.3M, 3),
            new(4, "Super nova", 320, 0.4M, 4),
            new(5, "Quasor", 100, 0.6M, 5),
            new(6, "Light Year", 30, 0.8M, 6),
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
