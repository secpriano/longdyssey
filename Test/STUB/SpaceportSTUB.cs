using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class SpaceportSTUB : ISpaceportDAL
    {
        static AstronomicalObjectSTUB PointOfInterestData = new();
        public List<SpaceportDTO> spaceports = new()
        {
            new(1, "EANLAM", PointOfInterestData.astronomicalObjects[0]),
            new(2, "EAUSNY", PointOfInterestData.astronomicalObjects[0]),
            new(3, "EAJPTO", PointOfInterestData.astronomicalObjects[0]),
            new(4, "EAUKLO", PointOfInterestData.astronomicalObjects[0]),
            new(5, "EARUMO", PointOfInterestData.astronomicalObjects[0]),
            new(6, "JUNLAM", PointOfInterestData.astronomicalObjects[4]),
            new(7, "NEVNHA", PointOfInterestData.astronomicalObjects[7]),
            new(8, "MERUMO", PointOfInterestData.astronomicalObjects[1]),
            new(9, "VEJPOS", PointOfInterestData.astronomicalObjects[2]),
            new(10, "MASACA", PointOfInterestData.astronomicalObjects[3]),
            new(11, "SASPBA", PointOfInterestData.astronomicalObjects[5]),
            new(12, "URBEBR", PointOfInterestData.astronomicalObjects[6]),
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
