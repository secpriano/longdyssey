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
            return;
        }
    }
}
