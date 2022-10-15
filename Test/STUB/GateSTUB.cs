using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class GateSTUB : IGateDAL
    {
        List<GateDTO> gates = new()
        {
            new(1, "A1", new(1, "EANLAM", new(1, "Earth", 1, 197, (decimal)7.155))),
            new(2, "A2", new(1, "EANLAM", new(1, "Earth", 1, 197, (decimal)7.155))),
            new(3, "B1", new(1, "EANLAM", new(1, "Earth", 1, 197, (decimal)7.155))),
            new(4, "A1", new(2, "JUUSNY", new(2, "Jupiter", 1, 26, 5))),
            new(5, "B1", new(3, "MAJPTO", new(3, "Mars", 1, 26, 4))),
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
