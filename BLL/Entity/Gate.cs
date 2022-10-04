using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class Gate
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public Spaceport Spaceport { get; set; }

        public Gate(ulong id, string name, Spaceport spaceport)
        {
            Id = id;
            Name = name;
            Spaceport = spaceport;
        }
    }
}
