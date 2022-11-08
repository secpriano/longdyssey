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
        public void GetAllFlightAmountRows()
        {
            // Arrange
            FlightContainer fc = new(new FlightSTUB());
            FlightSTUB fs = new();

            // Act
            int actual = fc.GetAll().Count;

            // Assert
            int expected = fs.GetAll().Count;
            Assert.AreEqual(expected, actual, "List not the same :(");
        }

        [TestMethod]
        public void DeleteFlightByID()
        {
            // Arrange
            FlightContainer fc = new(new FlightSTUB());
            FlightSTUB fs = new();

            // Act
            bool actual = fc.DeleteByID(0);

            // Assert
            bool expected = fs.DeleteByID(0);
            Assert.AreEqual(expected, actual, "Flight not deleted :(");
        }

        [TestMethod]
        public void AddFlight()
        {
            // Nog niet goed 

            // Arrange
            GateSTUB GateData = new();
            SpaceshipSTUB SpaceshipData = new();
            FlightDTO flightDTO = new(new(2069, 4, 8), 2, "JUJATO", GateData.gates[20], GateData.gates[21], SpaceshipData.spaceships[5]);
            Flight flight = new(new(2069, 4, 8), 2, new(GateData.gates[20]), new(GateData.gates[21]), new(SpaceshipData.spaceships[5]));
            FlightContainer fc = new(new FlightSTUB());
            FlightSTUB fs = new();
            bool expected = fs.Insert(flightDTO);

            // Act
            fc.Add(flight);

            // Assert
            bool actual = fs.DTOs.Contains(flightDTO);
            Assert.AreEqual(expected, actual, "Flight not added :(");
        }
    }
}