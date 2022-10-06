using BLL.Entity;
using IL.Interface.DAL;

namespace BLL.Container
{
    public class SpaceportContainer
    {
        ISpaceportDAL Data;

        public SpaceportContainer(ISpaceportDAL data)
        {
            Data = data;
        }

        public List<Spaceport> GetAll()
        {
            List<Spaceport> list = new();
            Data.GetAll().ToList().ForEach(spaceport => { list.Add(new(spaceport)); }); 
            return list;
        }
    }
}
