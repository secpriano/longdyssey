using IL.DTO;

namespace IL.Interface.DAL
{
    public interface ISpaceportDAL
    {
        public IEnumerable<SpaceportDTO> GetAll();
        public SpaceportDTO GetById(long id);
        public bool Insert(SpaceportDTO entity);
        public bool Update(SpaceportDTO entity);
        public bool Delete(long id);
    }
}
