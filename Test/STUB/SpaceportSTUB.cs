using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class SpaceportSTUB : ISpaceportDAL
    {
        static PointOfInterestSTUB PointOfInterestData = new();
        public List<SpaceportDTO> spaceports = new()
        {
            new(1, "EANLAM", PointOfInterestData.pointOfInterest[0]),
            new(2, "EAUSNY", PointOfInterestData.pointOfInterest[0]),
            new(3, "EAJPTO", PointOfInterestData.pointOfInterest[0]),
            new(4, "EAUKLO", PointOfInterestData.pointOfInterest[0]),
            new(5, "EARUMO", PointOfInterestData.pointOfInterest[0]),
            new(6, "JUNLAM", PointOfInterestData.pointOfInterest[4]),
            new(7, "NEVNHA", PointOfInterestData.pointOfInterest[7]),
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
