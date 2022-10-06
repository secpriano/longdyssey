using BLL.Entity;
using IL.DTO;
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
            Data.GetAll().ForEach(spaceport => { list.Add(new(spaceport)); }); 
            return list;
        }
    }
}
