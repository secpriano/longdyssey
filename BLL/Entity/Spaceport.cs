using IL.DTO;
using IL.Interface.DAL;

namespace BLL.Entity
{
    public class Spaceport
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AstronomicalObject AstronomicalObject { get; set; }
        public IGateDAL? GateDb { get; set; }

        public Spaceport(long id, string name, AstronomicalObject astronomicalObject, IGateDAL? gateDb)
        {
            Id = id;
            Name = name;
            AstronomicalObject = astronomicalObject;
            GateDb = gateDb;
        }

        public Spaceport(SpaceportDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            AstronomicalObject = new(dto.AstronomicalObject.Id, dto.AstronomicalObject.Name, dto.AstronomicalObject.Radius, dto.AstronomicalObject.Azimuth, dto.AstronomicalObject.Inclination, dto.AstronomicalObject.OrbitalSpeed);
        }

        public List<Gate> GetAllGates()
        {
            List<Gate> list = new();
            GateDb.GetBySpaceportId(Id).ForEach(gate => { list.Add(new(gate)); });
            return list;
        }

        public SpaceportDTO GetDTO() => new(Id, Name, AstronomicalObject.GetDTO());
    }
}
