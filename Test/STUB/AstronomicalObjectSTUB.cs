using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class AstronomicalObjectSTUB : ISpaceportDAL
    {
        public List<AstronomicalObjectDTO> astronomicalObject = new()
        {
            new(1, "Earth", 1.0M, 63.000M, 7.155M, 10M),
            new(2, "Mercury", 0.4M, 25.000M, 3.380M, 10M),
            new(3, "Venus", 0.7M, 189.000M, 3.860M, 10M),
            new(4, "Mars", 1.5M, 87.000M, 5.650M, 10M),
            new(5, "Jupiter", 5.2M, 318.000M, 6.090M, 10M),
            new(6, "Saturn", 9.5M, 258.000M, 5.510M, 10M),
            new(7, "Uranus", 19.2M, 97.000M, 6.480M, 10M),
            new(8, "Neptune", 30.1M, 203.000M, 6.430M, 10M),
        };
        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpaceportDTO> GetAll()
        {
            throw new NotImplementedException();
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