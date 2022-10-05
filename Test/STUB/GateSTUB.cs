using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    internal class GateSTUB : IGate
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
