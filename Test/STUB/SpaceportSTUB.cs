using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class SpaceportSTUB : ISpaceportDAL
    {
        List<SpaceportDTO> spaceports = new()
        {
            new(1, "EANLAM", 23, 475, 1),
            new(2, "JUUSNY", 234, 679, -232),
            new(3, "MAJPTO", -903, 929, 15)
        };

        public bool Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public List<SpaceportDTO> GetAll()
        {
            return spaceports; 
        }

        public SpaceportDTO GetById(ulong id)
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
