using BLL.Container;
using BLL.Entity;
using Test.STUB;

namespace Test
{
    [TestClass]
    public class UnitTestSearchFlight
    {
        [TestMethod]
        public void SearchFlightReturnsExpectedResult()
        {
            // Arrange
            /// STUB
            FlightSTUB flightStub = new();
            FlightContainer flightContainer = new(flightStub);
            SpaceportSTUB spaceportStub = new();
            SpaceportContainer spaceportContainer = new(spaceportStub);

            /// Search Query
            DateTime leaveDate = new(2050, 12, 21);
            long originSpaceportId = 1;
            long destinationSpaceportId = 6;
            string originAOandSpaceportName = "Earth | EANLAM";
            string destinationAOandSpaceportName = "Jupiter | JUNLAM";

            long travelers = 3;

            List<Flight> expectedFlights = flightStub.SearchFlights(leaveDate, originSpaceportId, destinationSpaceportId, travelers).Select(DTO => new Flight(DTO)).ToList();

            // Act
            Result<List<Flight>> actualFlights = flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, travelers);

            // Assert
            Assert.IsNotNull(actualFlights);
            Assert.AreEqual(null, actualFlights.ErrorMessage);
            Assert.AreEqual(null, actualFlights.PossibleFixesMessage);
            Assert.AreEqual(expectedFlights.Count, actualFlights.Data.Count);
            for (int i = 0; i < actualFlights.Data.Count; i++)
            {
                Assert.AreEqual(expectedFlights[i].Id, actualFlights.Data[i].Id);
            }
        }

        [TestMethod]
        public void SearchFlightHandlesInvalidInput()
        {
            // Arrange
            /// STUB
            FlightSTUB flightStub = new();
            FlightContainer flightContainer = new(flightStub);
            SpaceportSTUB spaceportStub = new();
            SpaceportContainer spaceportContainer = new(spaceportStub);

            /// Search Query
            DateTime leaveDate = new(2050, 12, 21);
            string originAOandSpaceportName = "Earth | EANLAM";
            string destinationAOandSpaceportName = "bla"; // Invalid
            long travelers = 3;

            // Act
            Result<List<Flight>> actualFlights = flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, travelers);

            // Assert
            // Verify that the search returns an appropriate error message
            Assert.AreEqual(null, actualFlights.Data);
            Assert.AreEqual("Error: invalid input", actualFlights.ErrorMessage);
            Assert.AreEqual("Possible fixes: Select one from the dropdown menu", actualFlights.PossibleFixesMessage);
            //Assert.AreEqual("Please enter a valid location.", actualFlights.ViewData.ModelState["originSpaceport"].Errors[0].ErrorMessage);
        }
    }
}
