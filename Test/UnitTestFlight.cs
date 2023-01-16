using BLL.Container;
using BLL.Entity;
using IL.DTO;
using Test.STUB;

namespace Test
{
    [TestClass]
    public class UnitTestFlight
    {
        [TestMethod]
        public void GetAllFlights_ReturnsExpectedResult()
        {
            // Arrange
            FlightSTUB flightStub = new();
            FlightContainer flightContainer = new(flightStub);
            
            List<Flight> expected = flightStub.GetAll().Select(DTO => new Flight(DTO)).ToList();

            // Act
            List<Flight> actual = flightContainer.GetAll();

            // Assert
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Spaceship.Id, actual[i].Spaceship.Id);
                Assert.AreEqual(expected[i].OriginGate.Id, actual[i].OriginGate.Id);
                Assert.AreEqual(expected[i].DestinationGate.Id, actual[i].DestinationGate.Id);
                Assert.AreEqual(expected[i].OriginGate.Spaceport.Id, actual[i].OriginGate.Spaceport.Id);
                Assert.AreEqual(expected[i].DestinationGate.Spaceport.Id, actual[i].DestinationGate.Spaceport.Id);
            }
        }

        [TestMethod]
        public void DeleteFlightById_CheckParameter_ParametersPassedInControllerIsTheSameInDAL()
        {
            // Arrange
            FlightSTUB flightStub = new();
            FlightContainer flightContainer = new(flightStub);

            // Act
            bool actualIsDeleted = flightContainer.DeleteByID(1);

            // Assert
            Assert.IsTrue(actualIsDeleted);
            Assert.AreEqual(1, flightStub.FlightId);
        }

        [TestMethod]
        public void DeleteFlightById_ReturnsExpectedResult()
        {
            // Arrange
            FlightSTUB flightStub = new();
            FlightContainer flightContainer = new(flightStub);

            int expected = flightStub.GetAll().Count - 1;

            // Act
            flightContainer.DeleteByID(1);

            // Assert
            Assert.AreEqual(expected, flightStub.GetAll().Count);
            Assert.IsFalse(flightStub.flights.Exists(flight => flight.Id == 1));
        }

        [TestMethod]
        public void AddFlight_ReturnsExpectedResult()
        {
            // Arrange
            GateSTUB GateData = new();
            SpaceshipSTUB SpaceshipData = new();
            FlightSTUB flightStub = new();
            FlightContainer flightContainer = new(flightStub);
            
            Flight expectedFlight = new(2, new(2069, 4, 8), 2, "YOYO1", new(GateData.gates[20]), new(GateData.gates[21]), new(SpaceshipData.spaceships[5]), null);

            // Act
            bool ActualIsAdded = flightContainer.Add(expectedFlight);

            // Assert
            Assert.IsTrue(ActualIsAdded);
            
            FlightDTO actualFlight = flightStub.flights.Find(flight => flight.Id == expectedFlight.Id);
            Assert.AreEqual(expectedFlight.Id, actualFlight.Id);
            Assert.AreEqual(expectedFlight.Spaceship.Id, actualFlight.Spaceship.Id);
            Assert.AreEqual(expectedFlight.OriginGate.Id, actualFlight.OriginGate.Id);
            Assert.AreEqual(expectedFlight.DestinationGate.Id, actualFlight.DestinationGate.Id);
            Assert.AreEqual(expectedFlight.OriginGate.Spaceport.Id, actualFlight.OriginGate.Spaceport.Id);
            Assert.AreEqual(expectedFlight.DestinationGate.Spaceport.Id, actualFlight.DestinationGate.Spaceport.Id);
        }
    }
}