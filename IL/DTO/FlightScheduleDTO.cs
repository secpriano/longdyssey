namespace IL.DTO
{
    public class FlightScheduleDTO
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public FlightScheduleDTO(long? id, string? name, DateTime? startDate, DateTime? endDate)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }                                     
}                                         
                                          