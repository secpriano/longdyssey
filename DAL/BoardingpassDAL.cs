using IL.DTO;
using IL.Interface.DAL;
using System.Data.SqlClient;
using System.Data;
using ExceptionHandler;

namespace DAL
{
    public class BoardingpassDAL : Database, IBoardingpassDAL
    {
        public bool BookSeatFromFlight(long seat, long flightId, long userId)
        {
            // Check if seat is already taken for this flight
            string cmdText = "SELECT * FROM Boardingpass WHERE Seat = @Seat AND FlightID = @FlightID";
            using SqlCommand checkCom = new(cmdText);
            checkCom.Parameters.Add("@Seat", SqlDbType.BigInt).Value = seat;
            checkCom.Parameters.Add("@FlightID", SqlDbType.BigInt).Value = flightId;
            
            DataTable dt = new();
            dt = Fetch(checkCom);

            if (dt.Rows.Count != 0)
            {
                throw new DALexception(ErrorType.SeatTaken, "Seat is already taken");
            }
            
            // If seat is available, book it
            cmdText = "INSERT INTO Boardingpass (Seat, FlightID, UserID) VALUES (@Seat, @FlightID, @UserID)";
            using SqlCommand com = new(cmdText);
            com.Parameters.Add("@Seat", SqlDbType.BigInt).Value = seat;
            com.Parameters.Add("@FlightID", SqlDbType.BigInt).Value = flightId;
            com.Parameters.Add("@UserID", SqlDbType.BigInt).Value = userId;

            return Persist(com);
        }

        public List<BoardingpassDTO> GetBoardingpassesByFlightId(long id)
        {
            string cmdText = "SELECT Boardingpass.Seat AS UserSeat, Flight.FlightID, Flight.DepartureTime, Flight.StatusFlight, Flight.FlightNumber, Flight.SpaceshipID, Spaceship.SpaceshipName, Spaceship.Seat AS SpaceshipSeat, Spaceship.Speed, Spaceship.SpaceshipRoleID, OriginGateID, DestinationGateID, OriginGate.GateName AS OriginGateName, DestinationGate.GateName AS DestinationGateName, OriginSpaceport.SpaceportID AS OriginSpaceportID, OriginSpaceport.SpaceportName AS OriginSpaceportName, DestinationSpaceport.SpaceportID AS DestinationSpaceportID, DestinationSpaceport.SpaceportName AS DestinationSpaceportName,OriginAstronomicalObject.AstronomicalObjectID AS OriginAstronomicalObjectID, OriginAstronomicalObject.AstronomicalObjectName AS OriginAstronomicalObjectName, OriginAstronomicalObject.Radius AS OriginAstronomicalObjectRadius, OriginAstronomicalObject.Azimuth AS OriginAstronomicalObjectAngleX, OriginAstronomicalObject.Inclination AS OriginAstronomicalObjectAngleY, OriginAstronomicalObject.OrbitalSpeed AS OriginAstronomicalObjectOrbitalSpeed, DestinationAstronomicalObject.AstronomicalObjectID AS DestinationAstronomicalObjectID, DestinationAstronomicalObject.AstronomicalObjectName AS DestinationAstronomicalObjectName, DestinationAstronomicalObject.Radius AS DestinationAstronomicalObjectRadius, DestinationAstronomicalObject.Azimuth AS DestinationAstronomicalObjectAngleX, DestinationAstronomicalObject.Inclination AS DestinationAstronomicalObjectAngleY, DestinationAstronomicalObject.OrbitalSpeed AS DestinationAstronomicalObjectOrbitalSpeed, UserAccount.UserID, UserAccount.FirstName, UserAccount.LastName, UserAccount.Email, UserAccount.SpaceMiles, UserAccount.IsLyMember  FROM Boardingpass  LEFT JOIN Flight ON Boardingpass.FlightID = Flight.FlightID  LEFT JOIN UserAccount ON Boardingpass.UserID = UserAccount.UserID  LEFT JOIN Gate AS OriginGate ON Flight.OriginGateID = OriginGate.GateID  LEFT JOIN Gate AS DestinationGate ON Flight.DestinationGateID = DestinationGate.GateID LEFT JOIN Spaceship ON Flight.SpaceshipID = Spaceship.SpaceshipID LEFT JOIN Spaceport AS OriginSpaceport ON OriginGate.SpaceportID = OriginSpaceport.SpaceportID LEFT JOIN Spaceport AS DestinationSpaceport ON DestinationGate.SpaceportID = DestinationSpaceport.SpaceportID  LEFT JOIN AstronomicalObject AS OriginAstronomicalObject  ON OriginSpaceport.AstronomicalObjectID = OriginAstronomicalObject.AstronomicalObjectID LEFT JOIN AstronomicalObject AS DestinationAstronomicalObject  ON DestinationSpaceport.AstronomicalObjectID = DestinationAstronomicalObject.AstronomicalObjectID WHERE Boardingpass.FlightID = @FlightId";

            using SqlCommand com = new(cmdText);
            com.Parameters.Add("@FlightId", SqlDbType.BigInt).Value = id;

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
                                    new AstronomicalObjectDTO(
                                        dt.Rows[i].Field<long>("OriginAstronomicalObjectID"),
                                        dt.Rows[i].Field<string>("OriginAstronomicalObjectName"),
                                        dt.Rows[i].Field<decimal>("OriginAstronomicalObjectRadius"),
                                        dt.Rows[i].Field<decimal>("OriginAstronomicalObjectAngleX"),
                                        dt.Rows[i].Field<decimal>("OriginAstronomicalObjectAngleY"),
                                        dt.Rows[i].Field<decimal>("OriginAstronomicalObjectOrbitalSpeed")
                                    )
                                )
                            ),
                            new GateDTO(
                                dt.Rows[i].Field<long>("DestinationGateID"),
                                dt.Rows[i].Field<string>("DestinationGateName"),
                                new SpaceportDTO(
                                    dt.Rows[i].Field<long>("DestinationSpaceportID"),
                                    dt.Rows[i].Field<string>("DestinationSpaceportName"),
                                    new AstronomicalObjectDTO(
                                        dt.Rows[i].Field<long>("DestinationAstronomicalObjectID"),
                                        dt.Rows[i].Field<string>("DestinationAstronomicalObjectName"),
                                        dt.Rows[i].Field<decimal>("DestinationAstronomicalObjectRadius"),
                                        dt.Rows[i].Field<decimal>("DestinationAstronomicalObjectAngleX"),
                                        dt.Rows[i].Field<decimal>("DestinationAstronomicalObjectAngleY"),
                                        dt.Rows[i].Field<decimal>("DestinationAstronomicalObjectOrbitalSpeed")
                                    )
                                )
                            ),
                            new SpaceshipDTO(
                                dt.Rows[i].Field<long>("SpaceshipID"),
                                dt.Rows[i].Field<string>("SpaceshipName"),
                                dt.Rows[i].Field<int>("SpaceshipSeat"),
                                dt.Rows[i].Field<decimal>("Speed"),
                                dt.Rows[i].Field<long>("SpaceshipRoleID")
                            ),
                            null
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
