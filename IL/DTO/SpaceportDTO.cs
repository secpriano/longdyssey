using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class SpaceportDTO
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }

        public SpaceportDTO(ulong id, string name, long x, long y, long z)
        {
            Id = id;
            Name = name;
            X = x;
            Y = y;
            Z = z;
        }
    }
}
