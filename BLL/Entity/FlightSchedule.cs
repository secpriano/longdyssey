using IL.DTO;

namespace BLL.Entity
{
    public class FlightSchedule
    {
        public long? Id { get; }
        public string? Name { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }

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
            if (dto != null)
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
