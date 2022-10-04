using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class GateDTO
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public SpaceportDTO Spaceport { get; set; }

        public GateDTO(ulong id, string name, SpaceportDTO spaceport)
        {
            Id = id;
            Name = name;
            Spaceport = spaceport;
        }
    }
}
