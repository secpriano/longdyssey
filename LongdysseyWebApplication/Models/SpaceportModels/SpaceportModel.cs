using IL.Interface.DAL;

namespace WebApplication.Models
{
    public class SpaceportModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AstronomicalObjectModel AstronomicalObject { get; set; }
        public IGateDAL? C { get; set; }

        public SpaceportModel(long id, string name, AstronomicalObjectModel astronomicalObject, IGateDAL? c)
        {
            Id = id;
            Name = name;
            AstronomicalObject = astronomicalObject;
            C = c;
        }
    }
}
