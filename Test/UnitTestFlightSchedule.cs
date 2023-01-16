using Algorithm;
using BLL.Entity;
using Test.STUB;

namespace Test;


[TestClass]
public class UnitTestFlightSchedule
{
    const byte minimumFlightsDepartingAday = 4;
    const byte minimumFlightsArrivingAndEDepartingAday = minimumFlightsDepartingAday * 2;
    
    [TestMethod]
    public void FlightScheduler_ReturnsExpectedResult()
    {
        // Arrange
        /// STUB
        GateSTUB gateStub = new();
        FlightScheduleSTUB flightScheduleStub = new();
        FlightSTUB flightStub = new();
        SpaceshipSTUB spaceshipStub = new();
        AstronomicalObjectSTUB astronomicalObjectStub = new();
        
        /// Algorithm with STUB
        FlightScheduler flightScheduler = new FlightScheduler(gateStub, flightScheduleStub, flightStub);
        
        // todo: randomize the input
        string flightScheduleName = "Its a wonderful flight";
        DateTime flightScheduleStartDate = new(2029, 12, 24);
        DateTime flightScheduleEndDate = new(2030, 1, 25);
        string spaceshipName = "Vaccuum Star";
        
        /// Minimum and maximum requirements result
        ulong daysBetween = (ulong)(flightScheduleEndDate - flightScheduleStartDate).Days;
        ulong totalMinimumFlights = daysBetween * minimumFlightsArrivingAndEDepartingAday;
        
        // Act
        /// Init shortest route algorithm
        ShortestRoute shortestRoute = new(spaceshipStub, spaceshipName, astronomicalObjectStub, flightScheduleStartDate);
        /// Run shortest route algorithm
        List<AstronomicalObject> Route = shortestRoute.CalculateBestRoute();

        /// Add flight schedule to database
        flightScheduler.InsertFlightSchedule(flightScheduleName, flightScheduleStartDate, flightScheduleEndDate);
        /// Get flight schedule from database
        FlightSchedule flightSchedule = flightScheduler.GetByName(flightScheduleName);
        /// Use flight schedule to add flights to database
        flightScheduler.GenerateFlightsFromFlightSchedule(spaceshipStub, flightSchedule, spaceshipName, Route);
        
        List<Flight> flights = flightStub.GetByFlightScheduleId((long)flightSchedule.Id).Select(flight => new Flight(flight)).ToList();
        
        // Assert
        Assert.IsTrue(totalMinimumFlights < (ulong)flights.Count);
    }
}