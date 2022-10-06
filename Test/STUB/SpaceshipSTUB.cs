using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class SpaceshipSTUB : ISpaceshipDAL
    {
        List<SpaceshipDTO> spaceships = new()
        {
            new(1, "Cosmic", 59000, 20, "Paradise"),
            new(2, "Saggittarus", 4895, 20, "Cruise"),
            new(3, "Vaccuum Star", 755, 25, "Super Jumbo"),
            new(4, "Super nova", 320, 30, "Jumbo"),
            new(5, "Quasor", 100, 35, "Jet"),
            new(6, "Light Year", 30, 50, "Scram Jet"),
        };

        public bool Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpaceshipDTO> GetAll()
        {
            return spaceships;
        }

        public SpaceshipDTO GetById(ulong id)
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
