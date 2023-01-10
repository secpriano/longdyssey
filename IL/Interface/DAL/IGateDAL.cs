using IL.DTO;

namespace IL.Interface.DAL
{
    public interface IGateDAL
    {
        public IEnumerable<GateDTO> GetAll();
        public List<GateDTO> GetBySpaceportId(long id);
        public GateDTO GetById(long id);
        public bool Insert(GateDTO entity);
        public bool Update(GateDTO entity);
        public bool Delete(long id);
        public GateDTO GetByAstronomicalObjectName(string name);
    }
}
