using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class SpaceportSTUB : ISpaceportDAL
    {
        List<SpaceportDTO> spaceports = new()
        {
            new(1, "EANLAM", new(1, "Earth", 1, 197, (decimal)7.155)),
            new(2, "JUUSNY", new(2, "Jupiter", 1, 26, 5)),
            new(3, "MAJPTO", new(3, "Mars", 1, 26, 4))
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
