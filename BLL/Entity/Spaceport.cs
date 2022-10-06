using IL.DTO;
using IL.Interface.DAL;

namespace BLL.Entity
{
    public class Spaceport
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }
        public IGateDAL? C { get; set; }

        public Spaceport(ulong id, string name, long x, long y, long z)
        {
            Id = id;
            Name = name;
            X = x;
            Y = y;
            Z = z;
        }

        public Spaceport(SpaceportDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            X = dto.X;
            Y = dto.Y;
            Z = dto.Z;
        }

        public List<Gate> GetAllGates()
        {
            List<Gate> list = new();
            C.GetBySpaceportId(Id).ForEach(gate => { list.Add(new(gate)); });
            return list;
        }
    }
}
