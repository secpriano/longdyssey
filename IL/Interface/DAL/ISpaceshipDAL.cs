using IL.DTO;

namespace IL.Interface.DAL
{
    public interface ISpaceportDAL
    {
        public List<SpaceportDTO> GetAll();
        public SpaceportDTO GetById(ulong id);
        public bool Insert(SpaceportDTO entity);
        public bool Update(SpaceportDTO entity);
        public bool Delete(ulong id);
    }
}
