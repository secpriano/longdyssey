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

        public List<Spaceport> GetAll() => Db.GetAll().Select(spaceport => new Spaceport(spaceport)).ToList();
    }
}
