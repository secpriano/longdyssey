using IL.DTO;
using IL.Interface.DAL;

namespace BLL.Entity
{
    public class Spaceport
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public PointOfInterest pointOfInterest { get; set; }
        public IGateDAL? C { get; set; }

        public Spaceport(long id, string name, PointOfInterest pointOfInterest, IGateDAL? c)
        {
            Id = id;
            Name = name;
            this.pointOfInterest = pointOfInterest;
            C = c;
        }

        public Spaceport(SpaceportDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            pointOfInterest = new(dto.PointOfInterest.Id, dto.PointOfInterest.Name, dto.PointOfInterest.Radius, dto.PointOfInterest.Azimuth, dto.PointOfInterest.Inclination);
        }

        public List<Gate> GetAllGates()
        {
            List<Gate> list = new();
            C.GetBySpaceportId(Id).ForEach(gate => { list.Add(new(gate)); });
            return list;
        }
    }
}
