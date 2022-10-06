using IL.DTO;

namespace IL.Interface.DAL
{
    public interface IGateDAL
    {
        public IEnumerable<GateDTO> GetAll();
        public List<GateDTO> GetBySpaceportId(ulong id);
        public GateDTO GetById(ulong id);
        public bool Insert(GateDTO entity);
        public bool Update(GateDTO entity);
        public bool Delete(ulong id);
    }
}
