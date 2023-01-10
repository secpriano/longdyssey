using IL.DTO;
using System.Xml.Linq;

namespace BLL.Entity
{
    public class FlightSchedule
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public FlightSchedule(long id, string name, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public FlightSchedule(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public FlightSchedule(FlightScheduleDTO dto)
        {
            if (dto == null)
            {
                Id = null; 
                Name = null; 
                StartDate = null; 
                EndDate = null;
            }
            else
            {
                Id = dto.Id;
                Name = dto.Name;
                StartDate = dto.StartDate;
                EndDate = dto.EndDate;
            }
        }

        public FlightScheduleDTO GetDTO() => new(Id, Name, StartDate, EndDate);
    }
}
