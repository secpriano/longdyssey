using BLL.Entity;
using IL.Interface.DAL;

namespace BLL.Container
{
    public class SpaceportContainer
    {
        private readonly ISpaceportDAL db;

        public SpaceportContainer(ISpaceportDAL data)
        {
            db = data;
        }

        public List<Spaceport> GetAll()
        {
            List<Spaceport> list = new();
            db.GetAll().ToList().ForEach(spaceport => { list.Add(new(spaceport)); }); 
            return list;
        }
    }
}
