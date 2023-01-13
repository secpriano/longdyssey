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
            /// Valid search should always return data
            Assert.IsNotNull(actualFlights);

            /// Error & fix messages should always be null
            Assert.AreEqual(null, actualFlights.errorAndFixMessages);

            /// Actual data amount should always be equal to expected data amount
            Assert.AreEqual(expectedFlights.Count, actualFlights.Data.Count);
            
            /// Actual data should always be the same as the expected data
            for (int i = 0; i < actualFlights.Data.Count; i++)
            {
                Assert.AreEqual(expectedFlights[i].Id, actualFlights.Data[i].Id);
            }
        }

        [TestMethod]
        public void SearchFlightHandlesInvalidInputInOrigin()
        {
            // Arrange
            /// STUB
            FlightSTUB flightStub = new();
            FlightContainer flightContainer = new(flightStub);
            SpaceportSTUB spaceportStub = new();
            SpaceportContainer spaceportContainer = new(spaceportStub);

            /// Search Query
            DateTime leaveDate = new(2050, 12, 21);
            string originAOandSpaceportName = "ping pong"; // Invalid
            string destinationAOandSpaceportName = "Jupiter | JUNLAM";
            long travelers = 3;

            /// Expected Result error & fix messages
            List<(string Error, string Fix)> expectedErrorAndFixMessages = new() {
                (Error: $"Origin spaceport '{originAOandSpaceportName}' does not exist.", Fix: "Please select a valid origin spaceport.")
            };

            // Act
            Result<List<Flight>> actualFlights = flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, travelers);

            // Assert
            /// Error should always return null data
            Assert.IsNull(actualFlights.Data);

            /// Actual error & fix messages should always be equal to expected error & fix messages
            for (int i = 0; i < expectedErrorAndFixMessages.Count; i++)
            {
                Assert.AreEqual(expectedErrorAndFixMessages[i], actualFlights.errorAndFixMessages[i]);
            }
        }
        
        [TestMethod]
        public void SearchFlightHandlesInvalidInputInDestination()
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
            string destinationAOandSpaceportName = "casablanca"; // Invalid
            long travelers = 3;
            
            /// Expected Result error & fix messages
            List<(string Error, string Fix)> expectedErrorAndFixMessages = new() {
                (Error: $"Destination spaceport '{destinationAOandSpaceportName}' does not exist.", Fix: "Please select a valid destination spaceport.")
            };

            // Act
            Result<List<Flight>> actualFlights = flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, travelers);

            // Assert
            /// Error should always return null data
            Assert.IsNull(actualFlights.Data);

            /// Actual error & fix messages should always be equal to expected error & fix messages
            for (int i = 0; i < expectedErrorAndFixMessages.Count; i++)
            {
                Assert.AreEqual(expectedErrorAndFixMessages[i], actualFlights.errorAndFixMessages[i]);
            }
        }

        [TestMethod]
        public void SearchFlightHandlesInvalidInputInOriginAndDestination()
        {
            // Arrange
            /// STUB
            FlightSTUB flightStub = new();
            FlightContainer flightContainer = new(flightStub);
            SpaceportSTUB spaceportStub = new();
            SpaceportContainer spaceportContainer = new(spaceportStub);

            /// Search Query
            DateTime leaveDate = new(2050, 12, 21);
            string originAOandSpaceportName = "ping pong"; // Invalid
            string destinationAOandSpaceportName = "casablanca"; // Invalid
            long travelers = 3;

            /// Expected Result error & fix messages
            List<(string Error, string Fix)> expectedErrorAndFixMessages = new() {
                (Error: $"Origin spaceport '{originAOandSpaceportName}' does not exist.", Fix: "Please select a valid origin spaceport."),
                (Error: $"Destination spaceport '{destinationAOandSpaceportName}' does not exist.", Fix: "Please select a valid destination spaceport.")
            };

            // Act
            Result<List<Flight>> actualFlights = flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, travelers);

            // Assert
            /// Error should always return null data
            Assert.IsNull(actualFlights.Data);

            /// Actual error & fix messages should always be equal to expected error & fix messages
            for (int i = 0; i < expectedErrorAndFixMessages.Count; i++)
            {
                Assert.AreEqual(expectedErrorAndFixMessages[i], actualFlights.errorAndFixMessages[i]);
            }
        }

        [TestMethod]
        public void SearchFlightHandlesInvalidInputInLeaveDate()
        {
            // Arrange
            /// STUB
            FlightSTUB flightStub = new();
            FlightContainer flightContainer = new(flightStub);
            SpaceportSTUB spaceportStub = new();
            SpaceportContainer spaceportContainer = new(spaceportStub);

            /// Search Query
            DateTime leaveDate = new(2000, 12, 21); // Invalid
            string originAOandSpaceportName = "Earth | EANLAM";
            string destinationAOandSpaceportName = "Jupiter | JUNLAM";
            long travelers = 3;

            /// Expected Result error & fix messages
            List<(string Error, string Fix)> expectedErrorAndFixMessages = new() {
                (Error: $"Leave date '{leaveDate}' can not be earlier than present date.", Fix: "Please select a date today or in the future.")
            };

            // Act
            Result<List<Flight>> actualFlights = flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, travelers);

            // Assert
            /// Error should always return null data
            Assert.IsNull(actualFlights.Data);

            /// Actual error & fix messages should always be equal to expected error & fix messages
            for (int i = 0; i < expectedErrorAndFixMessages.Count; i++)
            {
                Assert.AreEqual(expectedErrorAndFixMessages[i], actualFlights.errorAndFixMessages[i]);
            }
        }

        [TestMethod]
        public void SearchFlightHandlesInvalidInputInTravelersLessThan1()
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
            string destinationAOandSpaceportName = "Jupiter | JUNLAM";
            long amountTravelers = 0; // Invalid

            /// Expected Result error & fix messages
            List<(string Error, string Fix)> expectedErrorAndFixMessages = new() {
                (Error: $"Travelers '{amountTravelers}' can not be less than 1.", Fix: "Please select a number greater than 0.")
            };

            // Act
            Result<List<Flight>> actualFlights = flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, amountTravelers);

            // Assert
            /// Error should always return null data
            Assert.IsNull(actualFlights.Data);

            /// Actual error & fix messages should always be equal to expected error & fix messages
            for (int i = 0; i < expectedErrorAndFixMessages.Count; i++)
            {
                Assert.AreEqual(expectedErrorAndFixMessages[i], actualFlights.errorAndFixMessages[i]);
            }
        }

        [TestMethod]
        public void SearchFlightHandlesInvalidInputInTravelersHigherThan10()
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
            string destinationAOandSpaceportName = "Jupiter | JUNLAM";
            long amountTravelers = 11; // Invalid

            /// Expected Result error & fix messages
            List<(string Error, string Fix)> expectedErrorAndFixMessages = new() {
                (
                    Error: $"Travelers '{amountTravelers}' can not be higher than 10.",
                    Fix: "Please select a number less than 11."
                )            
            };

            // Act
            Result<List<Flight>> actualFlights = flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, amountTravelers);

            // Assert
            /// Error should always return null data
            Assert.IsNull(actualFlights.Data);

            /// Actual error & fix messages should always be equal to expected error & fix messages
            for (int i = 0; i < expectedErrorAndFixMessages.Count; i++)
            {
                Assert.AreEqual(expectedErrorAndFixMessages[i], actualFlights.errorAndFixMessages[i]);
            }

        }
    }
}
