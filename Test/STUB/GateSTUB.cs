using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class GateSTUB : IGateDAL
    {
        List<GateDTO> gates = new()
        {
            new(1, "A1", new(1, "EANLAM", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(2, "A1", new(2, "EAUSNY", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(3, "A1", new(3, "EAJPTO", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(4, "A1", new(4, "EAUKLO", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(5, "A1", new(5, "EARUMO", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(6, "A2", new(5, "EARUMO", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(7, "A2", new(4, "EAUKLO", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(8, "A2", new(3, "EAJPTO", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(9, "A2", new(2, "EAUSNY", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(10, "A2", new(1, "EANLAM", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(11, "B2", new(1, "EANLAM", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(12, "B2", new(2, "EAUSNY", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(13, "B2", new(3, "EAJPTO", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(14, "B2", new(4, "EAUKLO", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(15, "B2", new(5, "EARUMO", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(16, "C1", new(5, "EARUMO", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(17, "C1", new(4, "EAUKLO", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(18, "C1", new(3, "EAJPTO", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(19, "C1", new(2, "EAUSNY", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(20, "C1", new(1, "EANLAM", new(1, "Earth", 1.0M, 63.000M, 7.155M))),
            new(21, "A1", new(6, "JUNLAM", new(5, "Jupiter", 5.2M, 318.000M, 6.090M))),
            new(22, "A1", new(7, "NEVNHA", new(8, "Neptune", 30.1M, 203.000M, 6.430M))),
            new(23, "A2", new(7, "NEVNHA", new(8, "Neptune", 30.1M, 203.000M, 6.430M))),
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
