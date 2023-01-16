using BLL.Container;
using BLL.Entity;
using ExceptionHandler;
using IL.DTO;
using Test.STUB;

namespace Test
{
    [TestClass]
    public class UnitTestSearchFlight
    {
        [TestMethod]
        public void SearchFlight_CheckParameter_ParametersPassedInControllerIsTheSameInDAL()
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
            long amountSeats = 3;

            // Act
            flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, amountSeats);

            // Assert
            /// Check if the parameters are the same as the stub
            Assert.AreEqual(leaveDate, flightStub.LeaveDate);
            Assert.AreEqual(originSpaceportId, flightStub.OriginSpaceportId);
            Assert.AreEqual(destinationSpaceportId, flightStub.DestinationSpaceportId);
            Assert.AreEqual(amountSeats, flightStub.AmountSeats);
        }
        
        [TestMethod]
        public void SearchFlight_CheckMapping_DTOisTheSameAsEntity()
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
            long amountSeats = 3;

            List<FlightDTO> expectedFlights = flightStub.SearchFlights(leaveDate, originSpaceportId, destinationSpaceportId, amountSeats);
            
            // Act
            List<Flight> actualFlights = flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, amountSeats);
            
            // Assert
            /// Actual data should always be the same as the expected data
            for (int i = 0; i < expectedFlights.Count; i++)
            {
                Assert.AreEqual(expectedFlights[i].Id, actualFlights[i].Id);
                Assert.AreEqual(expectedFlights[i].OriginGate.Id, actualFlights[i].OriginGate.Id);
                Assert.AreEqual(expectedFlights[i].OriginGate.Spaceport.Id, actualFlights[i].OriginGate.Spaceport.Id);
                Assert.AreEqual(expectedFlights[i].OriginGate.Spaceport.AstronomicalObject.Id, actualFlights[i].OriginGate.Spaceport.AstronomicalObject.Id);
                Assert.AreEqual(expectedFlights[i].DestinationGate.Id, actualFlights[i].DestinationGate.Id);
                Assert.AreEqual(expectedFlights[i].DestinationGate.Spaceport.Id, actualFlights[i].DestinationGate.Spaceport.Id);
                Assert.AreEqual(expectedFlights[i].DestinationGate.Spaceport.AstronomicalObject.Id, actualFlights[i].DestinationGate.Spaceport.AstronomicalObject.Id);
            }
        }
        
        [TestMethod]
        public void SearchFlight_ReturnsExpectedResult()
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

            long amountSeats = 3;

            List<Flight> expectedFlights = flightStub.SearchFlights(leaveDate, originSpaceportId, destinationSpaceportId, amountSeats).Select(dto => new Flight(dto)).ToList();

            // Act
            List<Flight> actualFlights = flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, amountSeats);

            // Assert
            /// Valid search should always return data
            Assert.IsNotNull(actualFlights);

            /// Actual data amount should always be equal to expected data amount
            Assert.AreEqual(expectedFlights.Count, actualFlights.Count);
            
            /// Actual data should always be the same as the expected data
            for (int i = 0; i < actualFlights.Count; i++)
            {
                Assert.AreEqual(expectedFlights[i].Id, actualFlights[i].Id);
                Assert.AreEqual(expectedFlights[i].OriginGate.Id, actualFlights[i].OriginGate.Id);
                Assert.AreEqual(expectedFlights[i].OriginGate.Spaceport.Id, actualFlights[i].OriginGate.Spaceport.Id);
                Assert.AreEqual(expectedFlights[i].OriginGate.Spaceport.AstronomicalObject.Id, actualFlights[i].OriginGate.Spaceport.AstronomicalObject.Id);
                Assert.AreEqual(expectedFlights[i].DestinationGate.Id, actualFlights[i].DestinationGate.Id);
                Assert.AreEqual(expectedFlights[i].DestinationGate.Spaceport.Id, actualFlights[i].DestinationGate.Spaceport.Id);
                Assert.AreEqual(expectedFlights[i].DestinationGate.Spaceport.AstronomicalObject.Id, actualFlights[i].DestinationGate.Spaceport.AstronomicalObject.Id);
            }
        }

        [TestMethod]
        public void SearchFlight_ThrowsInvalidInputException_InputOriginCantFindSpaceport()
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
            long amountSeats = 3;

            /// Expected Result error & fix messages
            (string Error, string Fix) expectedErrorAndFixMessage = (Error: $"Origin spaceport '{originAOandSpaceportName}' does not exist.", Fix: "Please select a valid origin spaceport from the list.");

            // Act and Assert
            /// Right exception class for throwing this error
            InvalidInputException e = Assert.ThrowsException<InvalidInputException>(() => flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, amountSeats));

            /// Actual error & fix messages should always be equal to expected error & fix messages
            Assert.AreEqual(expectedErrorAndFixMessage, e.ErrorAndFixMessages.First());
        }
        
        [TestMethod]
        public void SearchFlight_ThrowsInvalidInputException_InputDestinationCantFindSpaceport()
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
            long amountSeats = 3;

            /// Expected Result error & fix messages
            (string Error, string Fix) expectedErrorAndFixMessage = (Error: $"Destination spaceport '{destinationAOandSpaceportName}' does not exist.", Fix: "Please select a valid destination spaceport from the list.");

            // Act and Assert
            /// Right exception class for throwing this error
            InvalidInputException e = Assert.ThrowsException<InvalidInputException>(() => flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, amountSeats));

            /// Actual error & fix messages should always be equal to expected error & fix messages
            Assert.AreEqual(expectedErrorAndFixMessage, e.ErrorAndFixMessages.First());
        }

        [TestMethod]
        public void SearchFlight_ThrowsInvalidInputException_InputLeaveDateIsInThePast()
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
            long amountSeats = 3;

            // if date is today, then set present time to leaveDate
            DateTime presentDate = DateTime.Now;
            if (presentDate.Date == leaveDate)
            {
                TimeSpan time = presentDate.TimeOfDay;
                time = TimeSpan.FromMinutes(Math.Ceiling(time.TotalMinutes));
                leaveDate = leaveDate.Date + time;
            }

            /// Expected Result error & fix messages
            (string Error, string Fix) expectedErrorAndFixMessage = (Error: $"Leave date '{leaveDate}' can not be earlier than {DateTime.Now}.", Fix: "Please select a future date.");

            // Act and Assert
            /// Right exception class for throwing this error
            InvalidInputException e = Assert.ThrowsException<InvalidInputException>(() => flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, amountSeats));

            /// Actual error & fix messages should always be equal to expected error & fix messages
            Assert.AreEqual(expectedErrorAndFixMessage, e.ErrorAndFixMessages.First());
        }

        [TestMethod]
        public void SearchFlight_ThrowsInvalidInputException_InputAmountSeatLessThanMinimum()
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
            long amountSeats = 0; // Invalid

            /// Expected Result error & fix messages
            (string Error, string Fix) expectedErrorAndFixMessage = (Error: $"Amount seat '{amountSeats}' can not be less than 1.", Fix: "Please select a number greater than 0.");

            // Act and Assert
            /// Right exception class for throwing this error
            InvalidInputException e = Assert.ThrowsException<InvalidInputException>(() => flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, amountSeats));

            /// Actual error & fix messages should always be equal to expected error & fix messages
            Assert.AreEqual(expectedErrorAndFixMessage, e.ErrorAndFixMessages.First());
        }

        [TestMethod]
        public void SearchFlight_ThrowsInvalidInputException_InputAmountSeatsHigherThanMaximum()
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
            long amountSeats = 11; // Invalid

            /// Expected Result error & fix messages
            (string Error, string Fix) expectedErrorAndFixMessages = (Error: $"Amount seats '{amountSeats}' can not be higher than 10.", Fix: "Please select a number less than 11.");

            // Act and Assert
            /// Right exception class for throwing this error
            InvalidInputException e = Assert.ThrowsException<InvalidInputException>(() => flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, amountSeats));

            /// Actual error & fix messages should always be equal to expected error & fix messages
            Assert.AreEqual(expectedErrorAndFixMessages, e.ErrorAndFixMessages.First());
        }

        // SearchFlight_ThrowsInvalidInputException_OriginAndDestinationCannotBeTheSame
        [TestMethod]
        public void SearchFlight_ThrowsInvalidInputException_OriginAndDestinationCannotBeTheSame()
        {
            // Arrange
            /// STUB
            FlightSTUB flightStub = new();
            FlightContainer flightContainer = new(flightStub);
            SpaceportSTUB spaceportStub = new();
            SpaceportContainer spaceportContainer = new(spaceportStub);

            /// Search Query
            DateTime leaveDate = new(2050, 12, 21);
            string originAOandSpaceportName = "Earth | EANLAM"; // Invalid
            string destinationAOandSpaceportName = "Earth | EANLAM"; // Invalid
            long amountSeats = 3;

            /// Expected Result error & fix messages
            (string Error, string Fix) expectedErrorAndFixMessage = (Error: $"Origin spaceport '{originAOandSpaceportName}' and destination spaceport '{destinationAOandSpaceportName}' can not be the same.", Fix: "Please select a different destination spaceport.");

            // Act and Assert
            /// Right exception class for throwing this error
            InvalidInputException e = Assert.ThrowsException<InvalidInputException>(() => flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, amountSeats));

            /// Actual error & fix messages should always be equal to expected error & fix messages
            Assert.AreEqual(expectedErrorAndFixMessage, e.ErrorAndFixMessages.First());
        }

        [TestMethod]
        public void SearchFlight_ThrowsInvalidInputException_InputAllInvalid()
        {
            // Arrange
            /// STUB
            FlightSTUB flightStub = new();
            FlightContainer flightContainer = new(flightStub);
            SpaceportSTUB spaceportStub = new();
            SpaceportContainer spaceportContainer = new(spaceportStub);

            /// Search Query
            DateTime leaveDate = new(2000, 12, 21); // Invalid
            string originAOandSpaceportName = "ping pong";  // Invalid
            string destinationAOandSpaceportName = "casablanca"; // Invalid
            long amountSeats = 11; // Invalid

            /// Expected Result error & fix messages
            List<(string Error, string Fix)> expectedErrorAndFixMessages = new() 
            {
                (Error: $"Leave date '{leaveDate}' can not be earlier than {DateTime.Now}.", Fix: "Please select a future date."),
                (Error: $"Origin spaceport '{originAOandSpaceportName}' does not exist.", Fix: "Please select a valid origin spaceport from the list."),
                (Error: $"Destination spaceport '{destinationAOandSpaceportName}' does not exist.", Fix: "Please select a valid destination spaceport from the list."),
                (Error: $"Amount seats '{amountSeats}' can not be higher than 10.", Fix: "Please select a number less than 11.")
            };

            // Act and Assert
            /// Right exception class for throwing this error
            InvalidInputException e = Assert.ThrowsException<InvalidInputException>(() => flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, amountSeats));

            /// Actual error & fix messages should always be equal to expected error & fix messages
            for (int i = 0; i < expectedErrorAndFixMessages.Count; i++)
            {
                Assert.AreEqual(expectedErrorAndFixMessages[i], e.ErrorAndFixMessages[i]);
            }
        }

        [TestMethod]
        public void SearchFlight_ThrowsErrorResponse_FlightsAreEmpty()
        {
            // Arrange
            /// STUB
            FlightSTUB flightStub = new();
            FlightContainer flightContainer = new(flightStub);
            SpaceportSTUB spaceportStub = new();
            SpaceportContainer spaceportContainer = new(spaceportStub);

            /// Search Query
            DateTime leaveDate = new(2050, 12, 21);
            string originAOandSpaceportName = "Earth | EAJPTO";
            string destinationAOandSpaceportName = "Neptune | NEVNHA"; /// from 'Earth | EAJPTO' to 'Neptune | NEVNHA' there are no flights
            long amountSeats = 3;

            /// Expected Result error type & fix messages
            ErrorType expectedErrorType = ErrorType.FlightsAreEmpty;
            string expectedErrorMessage = ErrorResponse.GetErrorMessage(expectedErrorType);

            // Act and Assert
            /// Right exception class for throwing this eror
            //ErrorResponse e = Assert.ThrowsException<ErrorResponse>(() => flightContainer.SearchFlights(spaceportContainer, leaveDate, amountSeats, originAOandSpaceportName, destinationAOandSpaceportName));
            ErrorResponse e = Assert.ThrowsException<ErrorResponse>(() => flightContainer.SearchFlights(spaceportContainer, leaveDate, originAOandSpaceportName, destinationAOandSpaceportName, amountSeats));

            /// Actual error type & error messages should always be equal to expected error type & error messages
            Assert.AreEqual(expectedErrorType, e.ErrorType);
            Assert.AreEqual(expectedErrorMessage, e.Message);
        }
    }
}
