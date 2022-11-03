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
            List<Spaceport> spaceports = new();
            Db.GetAll().ToList().ForEach(spaceport => { spaceports.Add(new(spaceport)); }); 
            return spaceports;
        }
    }
}
