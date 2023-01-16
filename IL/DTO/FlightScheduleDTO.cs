namespace IL.DTO
{
    public class FlightScheduleDTO
    {
        public long? Id { get; set; }
        public string? Name { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }

        public FlightScheduleDTO(long? id, string? name, DateTime? startDate, DateTime? endDate)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }                                     
}                                         
                                          