using IL.DTO;

namespace IL.Interface.DAL
{
    public interface IGateDAL
    {
        public IEnumerable<GateDTO> GetAll();
        public GateDTO GetById(ulong id);
        public bool Insert(GateDTO entity);
        public bool Update(GateDTO entity);
        public bool Delete(ulong id);
    }
}
