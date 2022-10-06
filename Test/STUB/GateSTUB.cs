using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class GateSTUB : IGateDAL
    {
        List<GateDTO> gates = new()
        {
            new(1, "A1", new SpaceportDTO(1, "EANLAM", 23, 475, 1)),
            new(2, "A2", new SpaceportDTO(1, "EANLAM", 23, 475, 1)),
            new(3, "B1", new SpaceportDTO(1, "EANLAM", 23, 475, 1)),
            new(4, "A1", new SpaceportDTO(2, "JUUSNY", 234, 679, -232)),
            new(5, "B1", new SpaceportDTO(3, "MAJPTO", -903, 929, 15)),
        };

        public bool Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GateDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public GateDTO GetById(ulong id)
        {
            throw new NotImplementedException();
        }

        public List<GateDTO> GetBySpaceportId(ulong id)
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
