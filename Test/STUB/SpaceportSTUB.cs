using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class SpaceportSTUB : ISpaceportDAL
    {
        List<SpaceportDTO> spaceports = new()
        {
            new(1, "EANLAM", new(1, "Earth", 1.0M, 63.000M, 7.155M)),
            new(2, "EAUSNY", new(1, "Earth", 1.0M, 63.000M, 7.155M)),
            new(3, "EAJPTO", new(1, "Earth", 1.0M, 63.000M, 7.155M)),
            new(4, "EAUKLO", new(1, "Earth", 1.0M, 63.000M, 7.155M)),
            new(5, "EARUMO", new(1, "Earth", 1.0M, 63.000M, 7.155M)),
            new(6, "JUNLAM", new(5, "Jupiter", 5.2M, 318.000M, 6.090M)),
            new(7, "NEVNHA", new(8, "Neptune", 30.1M, 203.000M, 6.430M)),
        };

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpaceportDTO> GetAll()
        {
            return spaceports; 
        }

        public SpaceportDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SpaceportDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SpaceportDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
