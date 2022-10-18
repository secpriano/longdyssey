using BLL.Entity;
using IL.Interface.DAL;

namespace BLL.Container
{
    public class SpaceportContainer
    {
        private readonly ISpaceportDAL Db;

        public SpaceportContainer(ISpaceportDAL db)
        {
            Db = db;
        }

        public List<Spaceport> GetAll()
        {
            List<Spaceport> list = new();
            Db.GetAll().ToList().ForEach(spaceport => { list.Add(new(spaceport)); }); 
            return list;
        }
    }
}
