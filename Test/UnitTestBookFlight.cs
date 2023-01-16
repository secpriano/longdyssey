using BLL.Entity;
using ExceptionHandler;
using IL.DTO;
using Test.STUB;

namespace Test;

[TestClass]
public class UnitTestBookFlight
{
        [TestMethod]
        public void BookFlight_ReturnsExpectedResult()
        {
            // Arrange
            FlightSTUB flightStub = new();
            UserSTUB userStub = new();
            BoardingpassSTUB boardingpassStub = new();
            
            Flight expectedFlight = new(flightStub.GetById(1));
            User expectedUser = new(userStub.GetById(2));
            long expectedSeat = 23;
            
            Boardingpass expectedBoardingpass = new(
                0,
                expectedFlight,
                expectedUser,
                expectedSeat
            );
            
            // Act
            bool IsBooked = Flight.BookSeat(boardingpassStub, expectedFlight.Id, expectedSeat, expectedUser.Id);
            
            // Assert
            Assert.IsTrue(IsBooked);
            
            Boardingpass actualBoardingpass = new(boardingpassStub.GetById(boardingpassStub.boardingpasses.Count));
            Assert.AreEqual(expectedBoardingpass.Id, actualBoardingpass.Id);
            Assert.AreEqual(expectedBoardingpass.Flight.Id, actualBoardingpass.Flight.Id);
            Assert.AreEqual(expectedBoardingpass.User.Id, actualBoardingpass.User.Id);
            Assert.AreEqual(expectedBoardingpass.Seat, actualBoardingpass.Seat);
        }
        
        [TestMethod]
        public void BookFlight_CheckParameter_ParametersPassedInControllerIsTheSameInDAL()
        {
            // Arrange
            FlightSTUB flightStub = new();
            UserSTUB userStub = new();
            BoardingpassSTUB boardingpassStub = new();
            
            Flight expectedFlight = new(flightStub.GetById(1));
            User expectedUser = new(userStub.GetById(2));
            long expectedSeat = 1;
            
            Boardingpass expectedBoardingpass = new(
                0,
                expectedFlight,
                expectedUser,
                expectedSeat
            );
            
            // Act
            Flight.BookSeat(boardingpassStub, expectedFlight.Id, expectedSeat, expectedUser.Id);
            
            // Assert
            Assert.AreEqual(expectedBoardingpass.Flight.Id, boardingpassStub.FlightId);
            Assert.AreEqual(expectedBoardingpass.User.Id, boardingpassStub.UserId);
            Assert.AreEqual(expectedBoardingpass.Seat, boardingpassStub.Seat);
        }

        [TestMethod]
        public void BookFlight_ThrowsErrorResponse_SeatIsAlreadyBooked()
        {
            // Arrange
            /// STUB
            FlightSTUB flightStub = new();
            UserSTUB userStub = new();
            BoardingpassSTUB boardingpassStub = new();
            
            /// Expected data to book
            Flight expectedFlight = new(flightStub.GetById(1));
            User expectedUser = new(userStub.GetById(4));
            long expectedSeat = 40; // Seat 40 is already booked
            
            /// Expected Result error type & fix messages
            ErrorType expectedErrorType = ErrorType.SeatTaken;
            string expectedErrorMessage = ErrorResponse.GetErrorMessage(expectedErrorType);

            // Act and Assert
            /// Right exception class for throwing this error
            ErrorResponse e = Assert.ThrowsException<ErrorResponse>(() => Flight.BookSeat(boardingpassStub, expectedFlight.Id, expectedSeat, expectedUser.Id));
            
            /// Actual error type & error messages should always be equal to expected error type & error messages
            Assert.AreEqual(expectedErrorType, e.ErrorType);
            Assert.AreEqual(expectedErrorMessage, e.Message);
        }
}