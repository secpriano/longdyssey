using IL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL.Interface
{
    public interface IFlight
    {
        public IEnumerable<FlightDTO> GetAll();
        public FlightDTO GetById(ulong id);
        public FlightDTO Insert(FlightDTO entity);
        public FlightDTO Update(FlightDTO entity);
        public FlightDTO Delete(ulong id);
    }
}
