using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class GateSTUB : IGateDAL
    {
        static SpaceportSTUB SpaceportData = new();
        public List<GateDTO> gates = new()
        {
            new(1, "A1", SpaceportData.spaceports[0]),
            new(2, "A1", SpaceportData.spaceports[1]),
            new(3, "A1", SpaceportData.spaceports[2]),
            new(4, "A1", SpaceportData.spaceports[3]),
            new(5, "A1", SpaceportData.spaceports[4]),
            new(6, "A2", SpaceportData.spaceports[4]),
            new(7, "A2", SpaceportData.spaceports[3]),
            new(8, "A2", SpaceportData.spaceports[2]),
            new(9, "A2", SpaceportData.spaceports[1]),
            new(10, "A2", SpaceportData.spaceports[0]),
            new(11, "B2", SpaceportData.spaceports[0]),
            new(12, "B2", SpaceportData.spaceports[1]),
            new(13, "B2", SpaceportData.spaceports[2]),
            new(14, "B2", SpaceportData.spaceports[3]),
            new(15, "B2", SpaceportData.spaceports[4]),
            new(16, "C1", SpaceportData.spaceports[4]),
            new(17, "C1", SpaceportData.spaceports[3]),
            new(18, "C1", SpaceportData.spaceports[2]),
            new(19, "C1", SpaceportData.spaceports[1]),
            new(20, "C1", SpaceportData.spaceports[0]),
            new(21, "A1", SpaceportData.spaceports[5]),
            new(22, "A1", SpaceportData.spaceports[6]),
            new(23, "A2", SpaceportData.spaceports[6]),
        };

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GateDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public GateDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public List<GateDTO> GetBySpaceportId(long id)
        {
            List<GateDTO> spaceportGates = new List<GateDTO>();
            gates.ForEach(gate => 
            {
                if (gate.Spaceport.Id == id)
                {
                    spaceportGates.Add(gate); 
                }
            });
            return spaceportGates;
        }

        public bool Insert(GateDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(GateDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
