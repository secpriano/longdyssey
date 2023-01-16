using BLL.Container;
using BLL.Entity;
using IL.DTO;
using Newtonsoft.Json;
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
            FlightSTUB fs = new();
            FlightContainer fc = new(fs);
            List<Flight> expected = new();
            fs.GetAll().ForEach(DTO =>
            {
                expected.Add(new(DTO));
            });

            // Act
            List<Flight> actual = fc.GetAll();

            // Assert
            ListToJsonAreEqual(expected, actual, "List not the same: (");
        }

        [TestMethod]
        public void DeleteFlightByID()
        {
            // Arrange
            FlightSTUB fs = new();
            FlightContainer fc = new(fs);
            bool notContainsObject = true;
            fs.flights.ForEach(DTO =>
            {
                if (DTO.Id == 1)
                {
                    notContainsObject = false;
                }
            });

            // Act
            bool actual = fc.DeleteByID(1);

            // Assert
            fs.flights.ForEach(DTO =>
            {
                if (DTO.Id != 1)
                {
                    notContainsObject = false;
                }
                else
                {
                    notContainsObject = true;
                }
            });

            bool expected = notContainsObject;
            Assert.AreEqual(expected, actual, "Flight not deleted :(");
        }

        [TestMethod]
        public void AddFlight()
        {
            // Nog niet goed 

            // Arrange
            GateSTUB GateData = new();
            SpaceshipSTUB SpaceshipData = new();
            FlightDTO flightDTO = new(new(2069, 4, 8), 2, "JUJATO", GateData.gates[20], GateData.gates[21], SpaceshipData.spaceships[5], null);
            Flight flight = new(new(2069, 4, 8), 2, "YOYO1", new(GateData.gates[20]), new(GateData.gates[21]), new(SpaceshipData.spaceships[5]), null);
            FlightSTUB fs = new();
            FlightContainer fc = new(fs);
            bool expected = fs.Insert(flightDTO);

            // Act
            fc.Add(flight);

            // Assert
            bool actual = fs.flights.Contains(flightDTO);
            Assert.AreEqual(expected, actual, "Flight not added :(");
        }

    public static bool ListToJsonAreEqual(object obj1, object obj2, string message)
    {
        if (ReferenceEquals(obj1, obj2)) return true;
    
        if (obj1 is null || obj2 is null) return false;
    
        if (obj1.GetType() != obj2.GetType()) return false;
    
        string objJson1 = JsonConvert.SerializeObject(obj1);
        string objJson2 = JsonConvert.SerializeObject(obj2);

        Assert.AreEqual(objJson1, objJson2, message);
        return objJson1 == objJson2;
    }


        [TestMethod]
        public void UserID2_BookFlightID1_With10Travelers_IsInsertedInSTUB()
        {
            // Arrange
            FlightSTUB flightSTUB = new();
            UserSTUB userSTUB = new();
            BoardingpassSTUB boardingpassSTUB = new();

            /// welke persoon bookt het
            User user = new(userSTUB.users[Index(2)]);

            /// welke zitplaats reserveren
            long seat = 10;

            /// Wat de boardingpass moet zijn
            Boardingpass expectedBoardingpass = new(new(flightSTUB.flights[Index(1)]), user, seat);

            // Act
            Boardingpass actualbBoardingpass = new();

            /// book vlucht
            Flight.BookSeat(boardingpassSTUB, Index(1), seat, user.Id);

            /// zoek in de stub waar het toegevoegd is
            boardingpassSTUB.boardingpasses.ForEach(boardingpass =>
            {
                if (boardingpass.Flight.Id == expectedBoardingpass.Flight.Id && boardingpass.User.Id == expectedBoardingpass.User.Id && boardingpass.Seat == expectedBoardingpass.Seat)
                {
                    actualbBoardingpass = new(boardingpass);
                }
            });

            // Assert
            /// vergelijk boardingpasses in Json formaat
            ListToJsonAreEqual(expectedBoardingpass, actualbBoardingpass, "Flight not booked :(");
        }

        [TestMethod]
        public void BookFlightQuery_UserID3_FlightID1_Travelers7_IsTheSameInSTUB()
        {
            // Arrange
            FlightSTUB flightSTUB = new();
            UserSTUB userSTUB = new();
            BoardingpassSTUB boardingpassSTUB = new();

            /// welke persoon bookt het
            User user = new(userSTUB.users[Index(3)]);

            /// welke zitplaats reserveren
            long seat = 7;

            /// Wat de query moet zijn
            List<long> expectedQueryParams = new()
            {
                flightSTUB.flights[Index(1)].Id,
                user.Id,
                seat
            };

            // Act
            /// book vlucht
            Flight.BookSeat(boardingpassSTUB, Index(1), seat, user.Id);

            /// Wat de query is
            List<long> actualQueryParams = new()
            {
                boardingpassSTUB.FlightId,
                boardingpassSTUB.UserId,
                boardingpassSTUB.Seat
            };


            // Assert
            /// Query parameters vergelijken
            for (int i = 0; i < expectedQueryParams.Count; i++)
            {
                Assert.AreEqual(expectedQueryParams[i], actualQueryParams[i], "Query in STUB not the same as when send");
            }
        }

        // test maken voor volle vliegtuig

        // test maken niet dezelfde zitplaats

        // test maken voor verkeerde input

        private static int Index(int id) => id - 1;
    }
}