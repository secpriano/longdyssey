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
            Assert.IsTrue(expected.SequenceEqual(actual, new FlightsEqualityComparer()), "List not the same: (");
        }

        [TestMethod]
        public void DeleteFlightByID()
        {
            // Arrange
            FlightSTUB fs = new();
            FlightContainer fc = new(fs);
            bool notContainsObject = true;
            fs.DTOs.ForEach(DTO =>
            {
                if (DTO.Id == 1)
                {
                    notContainsObject = false;
                }
            });

            // Act
            bool actual = fc.DeleteByID(1);

            // Assert
            fs.DTOs.ForEach(DTO =>
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
            FlightDTO flightDTO = new(new(2069, 4, 8), 2, "JUJATO", GateData.gates[20], GateData.gates[21], SpaceshipData.spaceships[5]);
            Flight flight = new(new(2069, 4, 8), 2, new(GateData.gates[20]), new(GateData.gates[21]), new(SpaceshipData.spaceships[5]));
            FlightSTUB fs = new();
            FlightContainer fc = new(fs);
            bool expected = fs.Insert(flightDTO);

            // Act
            fc.Add(flight);

            // Assert
            bool actual = fs.DTOs.Contains(flightDTO);
            Assert.AreEqual(expected, actual, "Flight not added :(");
        }

        [TestMethod]
        public void SearchFlight()
        {
            // Arrange
            long originSpaceport = 1;
            long destinationSpaceport = 6;
            long travelers = 3;
            DateTime leaveDate = new(2050, 12, 21);

            FlightSTUB fs = new();
            FlightContainer fc = new(fs);
            List<Flight> expected = new();
            fs.SearchFlights(leaveDate, originSpaceport, destinationSpaceport, travelers).ForEach(DTO =>
            {
                expected.Add(new(DTO));
            });

            // Act
            List<Flight> actual = fc.SearchFlights(leaveDate, originSpaceport, destinationSpaceport, travelers);

            // Assert
            Assert.IsTrue(expected.SequenceEqual(actual, new FlightsEqualityComparer()), "Flight search not the same: ("); // Works
        }
        public class FlightsEqualityComparer : IEqualityComparer<Flight>
        {
            public bool Equals(Flight flightInfo1, Flight flightInfo2)
            {
                if (ReferenceEquals(flightInfo1, flightInfo2)) return true;

                if (flightInfo1 is null || flightInfo2 is null) return false;

                return
                    flightInfo1.Id == flightInfo2.Id &&
                    flightInfo1.DepartureTime == flightInfo2.DepartureTime &&
                    flightInfo1.Status == flightInfo2.Status &&
                    flightInfo1.FlightNumber == flightInfo2.FlightNumber &&
                    flightInfo1.OriginGate.Id == flightInfo2.OriginGate.Id &&
                    flightInfo1.OriginGate.Name == flightInfo2.OriginGate.Name &&
                    flightInfo1.OriginGate.Spaceport.Id == flightInfo2.OriginGate.Spaceport.Id &&
                    flightInfo1.OriginGate.Spaceport.Name == flightInfo2.OriginGate.Spaceport.Name &&
                    flightInfo1.OriginGate.Spaceport.PointOfInterest.Id == flightInfo2.OriginGate.Spaceport.PointOfInterest.Id &&
                    flightInfo1.OriginGate.Spaceport.PointOfInterest.Name == flightInfo2.OriginGate.Spaceport.PointOfInterest.Name &&
                    flightInfo1.OriginGate.Spaceport.PointOfInterest.Radius == flightInfo2.OriginGate.Spaceport.PointOfInterest.Radius &&
                    flightInfo1.OriginGate.Spaceport.PointOfInterest.Azimuth == flightInfo2.OriginGate.Spaceport.PointOfInterest.Azimuth &&
                    flightInfo1.OriginGate.Spaceport.PointOfInterest.Inclination == flightInfo2.OriginGate.Spaceport.PointOfInterest.Inclination &&
                    flightInfo1.DestinationGate.Id == flightInfo2.DestinationGate.Id &&
                    flightInfo1.DestinationGate.Name == flightInfo2.DestinationGate.Name &&
                    flightInfo1.DestinationGate.Spaceport.Id == flightInfo2.DestinationGate.Spaceport.Id &&
                    flightInfo1.DestinationGate.Spaceport.Name == flightInfo2.DestinationGate.Spaceport.Name &&
                    flightInfo1.DestinationGate.Spaceport.PointOfInterest.Id == flightInfo2.DestinationGate.Spaceport.PointOfInterest.Id &&
                    flightInfo1.DestinationGate.Spaceport.PointOfInterest.Name == flightInfo2.DestinationGate.Spaceport.PointOfInterest.Name &&
                    flightInfo1.DestinationGate.Spaceport.PointOfInterest.Radius == flightInfo2.DestinationGate.Spaceport.PointOfInterest.Radius &&
                    flightInfo1.DestinationGate.Spaceport.PointOfInterest.Azimuth == flightInfo2.DestinationGate.Spaceport.PointOfInterest.Azimuth &&
                    flightInfo1.DestinationGate.Spaceport.PointOfInterest.Inclination == flightInfo2.DestinationGate.Spaceport.PointOfInterest.Inclination &&
                    flightInfo1.Spaceship.Id == flightInfo2.Spaceship.Id &&
                    flightInfo1.Spaceship.Name == flightInfo2.Spaceship.Name &&
                    flightInfo1.Spaceship.Seat == flightInfo2.Spaceship.Seat &&
                    flightInfo1.Spaceship.Speed == flightInfo2.Spaceship.Speed &&
                    flightInfo1.Spaceship.Role == flightInfo2.Spaceship.Role;
            }

            public int GetHashCode(Flight obj)
            {
                if (obj is null) return 0;

                return
                    obj.Id.GetHashCode() ^
                    obj.DepartureTime.GetHashCode() ^
                    obj.Status.GetHashCode() ^
                    obj.FlightNumber.GetHashCode() ^
                    obj.OriginGate.Id.GetHashCode() ^
                    obj.OriginGate.Name.GetHashCode() ^
                    obj.OriginGate.Spaceport.Id.GetHashCode() ^
                    obj.OriginGate.Spaceport.Name.GetHashCode() ^
                    obj.OriginGate.Spaceport.PointOfInterest.Id.GetHashCode() ^
                    obj.OriginGate.Spaceport.PointOfInterest.Name.GetHashCode() ^
                    obj.OriginGate.Spaceport.PointOfInterest.Radius.GetHashCode() ^
                    obj.OriginGate.Spaceport.PointOfInterest.Azimuth.GetHashCode() ^
                    obj.OriginGate.Spaceport.PointOfInterest.Inclination.GetHashCode() ^
                    obj.DestinationGate.Id.GetHashCode() ^
                    obj.DestinationGate.Name.GetHashCode() ^
                    obj.DestinationGate.Spaceport.Id.GetHashCode() ^
                    obj.DestinationGate.Spaceport.Name.GetHashCode() ^
                    obj.DestinationGate.Spaceport.PointOfInterest.Id.GetHashCode() ^
                    obj.DestinationGate.Spaceport.PointOfInterest.Name.GetHashCode() ^
                    obj.DestinationGate.Spaceport.PointOfInterest.Radius.GetHashCode() ^
                    obj.DestinationGate.Spaceport.PointOfInterest.Azimuth.GetHashCode() ^
                    obj.DestinationGate.Spaceport.PointOfInterest.Inclination.GetHashCode() ^
                    obj.Spaceship.Id.GetHashCode() ^
                    obj.Spaceship.Name.GetHashCode() ^
                    obj.Spaceship.Seat.GetHashCode() ^
                    obj.Spaceship.Speed.GetHashCode() ^
                    obj.Spaceship.Role.GetHashCode();
            }
        }
    }
}