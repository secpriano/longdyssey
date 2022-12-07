using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class SpaceportSTUB : ISpaceportDAL
    {
        static AstronomicalObjectSTUB PointOfInterestData = new();
        public List<SpaceportDTO> spaceports = new()
        {
            new(1, "EANLAM", PointOfInterestData.astronomicalObject[0]),
            new(2, "EAUSNY", PointOfInterestData.astronomicalObject[0]),
            new(3, "EAJPTO", PointOfInterestData.astronomicalObject[0]),
            new(4, "EAUKLO", PointOfInterestData.astronomicalObject[0]),
            new(5, "EARUMO", PointOfInterestData.astronomicalObject[0]),
            new(6, "JUNLAM", PointOfInterestData.astronomicalObject[4]),
            new(7, "NEVNHA", PointOfInterestData.astronomicalObject[7]),
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
