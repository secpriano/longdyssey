using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB;

public class FlightScheduleSTUB : IFlightScheduleDAL
{
    public List<FlightScheduleDTO> FlightSchedules = new()
    {
        new(1, "Test Existing Schedule", new DateTime(2030, 4, 13), new DateTime(2030, 5, 27))
    };
    
    public bool Insert(FlightScheduleDTO entity)
    {
        entity.Id = FlightSchedules.Count + 1;
        FlightSchedules.Add(entity);
        
        return FlightSchedules.Contains(entity);
    }

    public FlightScheduleDTO GetByName(string name) => FlightSchedules.FirstOrDefault(flightSchedules => flightSchedules.Name == name);
}