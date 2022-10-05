using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    internal class SpaceshipSTUB : ISpaceshipDAL
    {
        List<SpaceshipDTO> spaceships = new()
        {
            new(1, "Saggittarus", 4895, 20, "Cruise"),
            new(2, "VaccuumStar", 755, 25, "Super Jumbo"),
            new(3, "Super nova", 320, 30, "Jumbo"),
            new(4, "Quasor", 100, 35, "Taxi"),
            new(5, "LightYear", 30, 50, "Jet"),
        };

        public bool Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpaceshipDTO> GetAll()
        {
            throw new NotImplementedException();
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
