using IL.DTO;
using IL.Interface.DAL;

namespace BLL.Entity
{
    public class Spaceport
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public PointOfInterest PointOfInterest { get; set; }
        public IGateDAL? C { get; set; }

        public Spaceport(long id, string name, PointOfInterest pointOfInterest, IGateDAL? c)
        {
            Id = id;
            Name = name;
            PointOfInterest = pointOfInterest;
            C = c;
        }

        public Spaceport(SpaceportDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            PointOfInterest = new(dto.PointOfInterest.Id, dto.PointOfInterest.Name, dto.PointOfInterest.Radius, dto.PointOfInterest.Azimuth, dto.PointOfInterest.Inclination);
        }

        public List<Gate> GetAllGates()
        {
            List<Gate> list = new();
            C.GetBySpaceportId(Id).ForEach(gate => { list.Add(new(gate)); });
            return list;
        }

        public SpaceportDTO GetDTO() => new(Id, Name, PointOfInterest.GetDTO());
    }
}
