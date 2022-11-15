using IL.DTO;
using IL.Interface.DAL;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class BoardingpassDAL : Database, IBoardingpassDAL
    {
        public bool BookFlight(long seat, long flightId, long userId)
        {
            string cmdText = "INSERT INTO Boardingpass (Seat, FlightID, UserID) VALUES (@Seat, @FlightID, @UserID)";

            using SqlCommand com = new(cmdText);
            com.Parameters.Add("@Seat", SqlDbType.BigInt).Value = seat;
            com.Parameters.Add("@FlightID", SqlDbType.BigInt).Value = flightId;
            com.Parameters.Add("@UserID", SqlDbType.BigInt).Value = userId;

            return Persist(com);
        }

        public List<BoardingpassDTO> GetBookingByFlightId(long id)
        {
            string cmdText = "SELECT Boardingpass.Seat AS UserSeat, Flight.FlightID, Flight.DepartureTime, Flight.StatusFlight, Flight.FlightNumber, Flight.SpaceshipID, Spaceship.SpaceshipName, Spaceship.Seat AS SpaceshipSeat, Spaceship.Speed, Spaceship.SpaceshipRoleID, OriginGateID, DestinationGateID, OriginGate.GateName AS OriginGateName, DestinationGate.GateName AS DestinationGateName, OriginSpaceport.SpaceportID AS OriginSpaceportID, OriginSpaceport.SpaceportName AS OriginSpaceportName, DestinationSpaceport.SpaceportID AS DestinationSpaceportID, DestinationSpaceport.SpaceportName AS DestinationSpaceportName, OriginPointOfInterest.PointOfInterestID AS OriginPointOfInterestID, OriginPointOfInterest.PointOfInterestName AS OriginPointOfInterestName, OriginPointOfInterest.Radius AS OriginPointOfInterestRadius, OriginPointOfInterest.Azimuth AS OriginPointOfInterestAngleX, OriginPointOfInterest.Inclination AS OriginPointOfInterestAngleY, DestinationPointOfInterest.PointOfInterestID AS DestinationPointOfInterestID, DestinationPointOfInterest.PointOfInterestName AS DestinationPointOfInterestName, DestinationPointOfInterest.Radius AS DestinationPointOfInterestRadius, DestinationPointOfInterest.Azimuth AS DestinationPointOfInterestAngleX, DestinationPointOfInterest.Inclination AS DestinationPointOfInterestAngleY, UserAccount.UserID, UserAccount.FirstName, UserAccount.LastName, UserAccount.Email, UserAccount.SpaceMiles, UserAccount.IsLyMember FROM Boardingpass LEFT JOIN Flight ON Boardingpass.FlightID = Flight.FlightID LEFT JOIN UserAccount ON Boardingpass.UserID = UserAccount.UserID  LEFT JOIN Gate AS OriginGate ON Flight.OriginGateID = OriginGate.GateID LEFT JOIN Gate AS DestinationGate ON Flight.DestinationGateID = DestinationGate.GateID LEFT JOIN Spaceship ON Flight.SpaceshipID = Spaceship.SpaceshipID LEFT JOIN Spaceport AS OriginSpaceport ON OriginGate.SpaceportID = OriginSpaceport.SpaceportID LEFT JOIN Spaceport AS DestinationSpaceport ON DestinationGate.SpaceportID = DestinationSpaceport.SpaceportID LEFT JOIN PointOfInterest AS OriginPointOfInterest ON OriginSpaceport.PointOfInterestID = OriginPointOfInterest.PointOfInterestID LEFT JOIN PointOfInterest AS DestinationPointOfInterest ON DestinationSpaceport.PointOfInterestID = DestinationPointOfInterest.PointOfInterestID";

            using SqlCommand com = new(cmdText);

            DataTable dt = new();
            dt = Fetch(com);

            List<BoardingpassDTO> DTOs = new();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BoardingpassDTO test = new(
                        new FlightDTO(
                            dt.Rows[i].Field<long>("FlightID"),
                            dt.Rows[i].Field<DateTime>("DepartureTime"),
                            dt.Rows[i].Field<long>("StatusFlight"),
                            dt.Rows[i].Field<string>("FlightNumber"),
                            new GateDTO(
                                dt.Rows[i].Field<long>("OriginGateID"),
                                dt.Rows[i].Field<string>("OriginGateName"),
                                new SpaceportDTO(
                                    dt.Rows[i].Field<long>("OriginSpaceportID"),
                                    dt.Rows[i].Field<string>("OriginSpaceportName"),
                                    new PointOfInterestDTO(
                                        dt.Rows[i].Field<long>("OriginPointOfInterestID"),
                                        dt.Rows[i].Field<string>("OriginPointOfInterestName"),
                                        dt.Rows[i].Field<decimal>("OriginPointOfInterestRadius"),
                                        dt.Rows[i].Field<decimal>("OriginPointOfInterestAngleX"),
                                        dt.Rows[i].Field<decimal>("OriginPointOfInterestAngleY")
                                    )
                                )
                            ),
                            new GateDTO(
                                dt.Rows[i].Field<long>("DestinationGateID"),
                                dt.Rows[i].Field<string>("DestinationGateName"),
                                new SpaceportDTO(
                                    dt.Rows[i].Field<long>("DestinationSpaceportID"),
                                    dt.Rows[i].Field<string>("DestinationSpaceportName"),
                                    new PointOfInterestDTO(
                                        dt.Rows[i].Field<long>("DestinationPointOfInterestID"),
                                        dt.Rows[i].Field<string>("DestinationPointOfInterestName"),
                                        dt.Rows[i].Field<decimal>("DestinationPointOfInterestRadius"),
                                        dt.Rows[i].Field<decimal>("DestinationPointOfInterestAngleX"),
                                        dt.Rows[i].Field<decimal>("DestinationPointOfInterestAngleY")
                                    )
                                )
                            ),
                            new SpaceshipDTO(
                                dt.Rows[i].Field<long>("SpaceshipID"),
                                dt.Rows[i].Field<string>("SpaceshipName"),
                                dt.Rows[i].Field<int>("SpaceshipSeat"),
                                dt.Rows[i].Field<decimal>("Speed"),
                                dt.Rows[i].Field<long>("SpaceshipRoleID")
                            )
                        ),
                        new UserDTO(
                            dt.Rows[i].Field<long>("UserID"),
                            dt.Rows[i].Field<string>("FirstName"),
                            dt.Rows[i].Field<string>("LastName"),
                            dt.Rows[i].Field<string>("Email"),
                            dt.Rows[i].Field<long>("SpaceMiles"),
                            dt.Rows[i].Field<bool>("IsLyMember")
                        ),
                        dt.Rows[i].Field<long>("UserSeat")
                );
                DTOs.Add(test);
            }

            return DTOs;
        }

        public bool DeleteByID(long id)
        {
            throw new NotImplementedException();
        }

        public List<BoardingpassDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public BoardingpassDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(BoardingpassDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(BoardingpassDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
