using Algorithm;
using BLL.Entity;
using Test.STUB;

namespace Test;


[TestClass]
public class UnitTestFlightSchedule
{
    const byte minimumFlightsDepartingAday = 3;
    const byte minimumFlightsArrivingAndEDepartingAday = minimumFlightsDepartingAday * 2;
    
    [TestMethod]
    public void FlightScheduler_InsertFlightSchedule_ReturnsExpectedResult()
    {
        /// STUB
        GateSTUB gateStub = new();
        FlightScheduleSTUB flightScheduleStub = new();
        FlightSTUB flightStub = new();
        
        /// Algorithm with STUB
        FlightScheduler flightScheduler = new FlightScheduler(gateStub, flightScheduleStub, flightStub);
        
        FlightSchedule expectedFlightSchedule = new(
            "Its a wonderful flight",
            new(2029, 12, 24),
            new(2030, 1, 25)
        );
        
        // Act
        /// Add flight schedule to database
        flightScheduler.InsertFlightSchedule(expectedFlightSchedule.Name, (DateTime)expectedFlightSchedule.StartDate, (DateTime)expectedFlightSchedule.EndDate);
        
        
        // Assert
        /// Find flight schedule in database
        FlightSchedule ActualflightScheduleFromFlightScheduleSTUB = flightScheduleStub.FlightSchedules
            .Where(flightSchedule => flightSchedule.Name == expectedFlightSchedule.Name)
            .Select(flightSchedule => new FlightSchedule(flightSchedule))
            .FirstOrDefault();
        
         /// flight schedule from database should be not null
        Assert.IsNotNull(ActualflightScheduleFromFlightScheduleSTUB);
        
        /// Check if flight schedule is added to database
        Assert.AreEqual(expectedFlightSchedule.Name, ActualflightScheduleFromFlightScheduleSTUB.Name);
        Assert.AreEqual(expectedFlightSchedule.StartDate, ActualflightScheduleFromFlightScheduleSTUB.StartDate);
        Assert.AreEqual(expectedFlightSchedule.EndDate, ActualflightScheduleFromFlightScheduleSTUB.EndDate);
    }

    [TestMethod]
    public void FlightScheduler_GetByName_ReturnsExpectedResult()
    {
         /// STUB
        GateSTUB gateStub = new();
        FlightScheduleSTUB flightScheduleStub = new();
        FlightSTUB flightStub = new();
        
        /// Algorithm with STUB
        FlightScheduler flightScheduler = new FlightScheduler(gateStub, flightScheduleStub, flightStub);
        
        FlightSchedule expectedFlightSchedule = new(
            "Its a wonderful flight",
            new(2029, 12, 24),
            new(2030, 1, 25)
        );
        
        // Act
        /// Add flight schedule to database
        flightScheduler.InsertFlightSchedule(expectedFlightSchedule.Name, (DateTime)expectedFlightSchedule.StartDate, (DateTime)expectedFlightSchedule.EndDate);
        /// Get flight schedule from database
        FlightSchedule ActualflightScheduleFromFlightScheduler = flightScheduler.GetByName(expectedFlightSchedule.Name);
        
        
        // Assert
         /// flight schedule from flight scheduler get by name should be not null
        Assert.IsNotNull(ActualflightScheduleFromFlightScheduler);
        
        /// Check if flight schedule is added to database and returned from flight scheduler by name
        Assert.AreEqual(expectedFlightSchedule.Name, ActualflightScheduleFromFlightScheduler.Name);
        Assert.AreEqual(expectedFlightSchedule.StartDate, ActualflightScheduleFromFlightScheduler.StartDate);
        Assert.AreEqual(expectedFlightSchedule.EndDate, ActualflightScheduleFromFlightScheduler.EndDate);
    }

    [TestMethod]
    public void FlightScheduler_CalculateDistance_ReturnsExpectedResult()
    {
        // Arrange
        /// STUB
        AstronomicalObject origin = new(1, "Object A", 10, 0, 0, 0);
        AstronomicalObject destination = new(1, "Object B", 10, 180, 0, 0);
        
        /// Convert shperical coordinates to cartesian coordinates
        origin.SphericalToCartesianCoordinates(out double[] originCoordinates);
        destination.SphericalToCartesianCoordinates(out double[] destinationCoordinates);
        
        /// Distance between two points on a sphere using the distance formula
        double expectedDistance = Math.Sqrt(
            Math.Pow(originCoordinates[(int)AstronomicalObject.Coordinates.X] - destinationCoordinates[(int)AstronomicalObject.Coordinates.X], 2)
            + 
            Math.Pow(originCoordinates[(int)AstronomicalObject.Coordinates.Y] - destinationCoordinates[(int)AstronomicalObject.Coordinates.Y], 2)
            + 
            Math.Pow(originCoordinates[(int)AstronomicalObject.Coordinates.Z] - destinationCoordinates[(int)AstronomicalObject.Coordinates.Z], 2)
            );

        // Act
        double actualDistance = FlightScheduler.CalculateDistance(origin, destination);
        
        // Assert
        // Expected distance should be equal to actual distance
        Assert.AreEqual(expectedDistance, actualDistance);
    }
    
    [TestMethod]
    public void FlightScheduler_AUtoKMconverter_ReturnsExpectedResult()
    {
        // Arrange
        Random random = new();
        /// Random distance in AU
        decimal randomDistance = random.Next(1, 100);
        /// Expected distance in KM
        decimal expectedDistance = 149597870.7M * randomDistance;
        
        // Act
        /// Convert Astronomical Unit to Kilometer
        decimal actualDistance = FlightScheduler.AUtoKm(randomDistance);
        
        // Assert
        /// Expected distance should be equal to converted actual distance
        Assert.AreEqual(expectedDistance, actualDistance);
    }
    
    [TestMethod]
    public void FlightScheduler_CalculateTravelTimeHour_ReturnsExpectedResult()
    {
        // Arrange
        /// STUB
        GateSTUB gateStub = new();
        FlightScheduleSTUB flightScheduleStub = new();
        FlightSTUB flightStub = new();

        /// Algorithm with STUB
        FlightScheduler flightScheduler = new FlightScheduler(gateStub, flightScheduleStub, flightStub);

        flightScheduler.Spaceship = new(1, "Test spaceship", 50, 0.5M, 1);
        decimal expectedTimeHour = 27.72M;
        
        // Act
        /// Actual travel time in hour = distance / speed
        decimal actualTimeHour = flightScheduler.CalculateTravelTimeHour(100);
        
        /// Expected travel time in hour should be equal to actual travel time in hour
        Assert.AreEqual(expectedTimeHour, actualTimeHour, 1M);
    }
    
    [TestMethod]
    public void FlightScheduler_CalculateSpaceshipsPerAO_ReturnsExpectedResult()
    {
        // Arrange
        /// STUB
        GateSTUB gateStub = new();
        FlightScheduleSTUB flightScheduleStub = new();
        FlightSTUB flightStub = new();

        /// Algorithm with STUB
        FlightScheduler flightScheduler = new FlightScheduler(gateStub, flightScheduleStub, flightStub);
        
        /// expected number of spaceships per astronomical object to travel between them
        ulong expectedSpaceships = 15;
        
        // Act
        /// Calculate number of spaceships per astronomical object to travel between them by travel time between them
        flightScheduler.CalculateSpaceshipsPerAO(120);
        
        /// Expected number of spaceships per astronomical object should be equal to actual number of spaceships per astronomical object
        Assert.AreEqual(expectedSpaceships, flightScheduler.spaceshipsOnAO.First());
    }
    
    [TestMethod]
    public void FlightScheduler_CalculateOutwardAndReturnFlightsStartingDepartureTimes_ReturnsExpectedResult()
    {
        // Arrange
        /// STUB
        GateSTUB gateStub = new();
        FlightScheduleSTUB flightScheduleStub = new();
        FlightSTUB flightStub = new();
        AstronomicalObjectSTUB astronomicalObjectStub = new();
        
        /// Algorithm with STUB
        FlightScheduler flightScheduler = new FlightScheduler(gateStub, flightScheduleStub, flightStub);
        
        flightScheduler.FlightSchedule = new(1, "Test schedule", new DateTime(2029, 12, 24), new DateTime(2030, 1, 25));
        
        flightScheduler.Spaceship = new(1, "Test spaceship", 50, 0.5M, 1);
        
        flightScheduler.Route = astronomicalObjectStub.astronomicalObjects.Select(AstronomicalObject => new AstronomicalObject(AstronomicalObject)).ToList();

        // Act
        /// Calculate outward and return flights starting departure times
        flightScheduler.CalculateOutwardAndReturnFlightsStartingDepartureTimes();
        
        // Assert
        /// Needed flights should not be empty after method call
        Assert.IsTrue(flightScheduler.NeededFlights.Count > 0);
        
        /// Every flight should have a origin and destination and it cannot be the same
        flightScheduler.NeededFlights.ForEach(flight =>
        {
            Assert.IsNotNull(flight.OriginGate);
            Assert.IsNotNull(flight.DestinationGate);
            Assert.AreNotEqual(flight.OriginGate, flight.DestinationGate);
        });
        
        /// Needed flights should have every astronomical object in route
        flightScheduler.Route.ForEach(astronomicalObject =>
        {
            Assert.IsTrue(flightScheduler.NeededFlights.Exists(flight => flight.OriginGate.Spaceport.AstronomicalObject.Id == astronomicalObject.Id));
            Assert.IsTrue(flightScheduler.NeededFlights.Exists(flight => flight.DestinationGate.Spaceport.AstronomicalObject.Id == astronomicalObject.Id));
        });
    }
    
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
        List<AstronomicalObject> route = shortestRoute.CalculateBestRoute();

        /// Add flight schedule to database
        flightScheduler.InsertFlightSchedule(flightScheduleName, flightScheduleStartDate, flightScheduleEndDate);
        /// Get flight schedule from database
        FlightSchedule flightSchedule = flightScheduler.GetByName(flightScheduleName);
        /// Use flight schedule to add flights to database
        flightScheduler.GenerateFlightsFromFlightSchedule(spaceshipStub, flightSchedule, spaceshipName, route);

        List<Flight> flights = flightStub.GetByFlightScheduleId((long)flightSchedule.Id)
            .Select(flight => new Flight(flight)).ToList();

        // Assert
        /// Minimum requirement for flights departing a day
        Assert.IsTrue(totalMinimumFlights * (ulong)route.Count < (ulong)flights.Count);
        
        /// Every route location has a flight departing and arriving
        for (int i = 0; i < route.Count; i++)
        {
            Assert.IsTrue(flightStub.flights.Exists(flight => flight.OriginGate.Spaceport.AstronomicalObject.Id == route[i].Id));
            Assert.IsTrue(flightStub.flights.Exists(flight => flight.DestinationGate.Spaceport.AstronomicalObject.Id == route[i].Id));
        }
        
        /// from start date to end date, check every day if there are the minimum flights departing between 00.00 and 23.59
        for (DateTime date = flightScheduleStartDate; date < flightScheduleEndDate; date = date.AddDays(1))
        {
            ulong flightsInADay = (ulong)flights.Where(flight => flight.DepartureTime >= date && flight.DepartureTime <= date.AddDays(1)).Count();
            Assert.IsTrue(flightsInADay >= totalMinimumFlights);
        }
        
        /// from start date to end date, check every day at every route if there are the minimum flights departing between 00.00 and 23.59
        for (DateTime date = flightScheduleStartDate; date < flightScheduleEndDate; date = date.AddDays(1))
        {
            for (int i = 0; i < route.Count; i++)
            {
                ulong flightsInADay = (ulong)flights.Where(flight => flight.DepartureTime >= date && flight.DepartureTime <= date.AddDays(1) && flight.OriginGate.Spaceport.AstronomicalObject.Id == route[i].Id).Count();
                Assert.IsTrue(flightsInADay >= minimumFlightsDepartingAday);
            }
        }
    }
}
