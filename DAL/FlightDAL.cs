using IL.DTO;
using System.Data.SqlClient;
using System.Data;
using IL.Interface.DAL;

namespace DAL
{
    public class FlightDAL : Database, IFlightDAL
    {
        public bool DeleteByID(long id)
        {
            string cmdText = "DELETE FROM Flight WHERE FlightID = @ID";

            using SqlCommand com = new(cmdText);

            com.Parameters.AddWithValue("@ID", id);

            return Persist(com);
        }

        public List<FlightDTO> GetAll()
        {
            string cmdText = "SELECT FlightID, DepartureTime,StatusFlight,FlightNumber,Flight.SpaceshipID,Spaceship.SpaceshipName,Spaceship.Seat,Spaceship.Speed,Spaceship.SpaceshipRoleID,OriginGateID,DestinationGateID,OriginGate.GateName AS OriginGateName, DestinationGate.GateName AS DestinationGateName,OriginSpaceport.SpaceportID AS OriginSpaceportID,OriginSpaceport.SpaceportName AS OriginSpaceportName,DestinationSpaceport.SpaceportID AS DestinationSpaceportID,DestinationSpaceport.SpaceportName AS DestinationSpaceportName,OriginPointOfInterest.PointOfInterestID AS OriginPointOfInterestID,OriginPointOfInterest.PointOfInterestName AS OriginPointOfInterestName,OriginPointOfInterest.Radius AS OriginPointOfInterestRadius,OriginPointOfInterest.Azimuth AS OriginPointOfInterestAngleX,OriginPointOfInterest.Inclination AS OriginPointOfInterestAngleY,DestinationPointOfInterest.PointOfInterestID AS DestinationPointOfInterestID,DestinationPointOfInterest.PointOfInterestName AS DestinationPointOfInterestName,DestinationPointOfInterest.Radius AS DestinationPointOfInterestRadius,DestinationPointOfInterest.Azimuth AS DestinationPointOfInterestAngleX,DestinationPointOfInterest.Inclination AS DestinationPointOfInterestAngleY  FROM Flight  LEFT JOIN Gate AS OriginGate  ON Flight.OriginGateID = OriginGate.GateID  LEFT JOIN Gate  AS DestinationGate  ON Flight.DestinationGateID = DestinationGate.GateID  LEFT JOIN Spaceship   ON Flight.SpaceshipID = Spaceship.SpaceshipID  LEFT JOIN Spaceport AS OriginSpaceport  ON OriginGate.SpaceportID = OriginSpaceport.SpaceportID  LEFT JOIN Spaceport AS DestinationSpaceport  ON DestinationGate.SpaceportID = DestinationSpaceport.SpaceportID  LEFT JOIN PointOfInterest AS OriginPointOfInterest  ON OriginSpaceport.PointOfInterestID = OriginPointOfInterest.PointOfInterestID  LEFT JOIN PointOfInterest AS DestinationPointOfInterest  ON DestinationSpaceport.PointOfInterestID = DestinationPointOfInterest.PointOfInterestID";

            using SqlCommand com = new(cmdText);

            DataTable dt = new();
            dt = Fetch(com);

            List<FlightDTO> DTOs = new();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTOs.Add(
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
                            dt.Rows[i].Field<int>("Seat"),
                            dt.Rows[i].Field<decimal>("Speed"),
                            dt.Rows[i].Field<long>("SpaceshipRoleID")
                        )
                    )
                );
            }

            return DTOs;
        }

        public FlightDTO GetById(long id)
        {
            string cmdText = "SELECT FlightID, DepartureTime,StatusFlight,FlightNumber,Flight.SpaceshipID,Spaceship.SpaceshipName,Spaceship.Seat,Spaceship.Speed,Spaceship.SpaceshipRoleID,OriginGateID,DestinationGateID,OriginGate.GateName AS OriginGateName, DestinationGate.GateName AS DestinationGateName,OriginSpaceport.SpaceportID AS OriginSpaceportID,OriginSpaceport.SpaceportName AS OriginSpaceportName,DestinationSpaceport.SpaceportID AS DestinationSpaceportID,DestinationSpaceport.SpaceportName AS DestinationSpaceportName,OriginPointOfInterest.PointOfInterestID AS OriginPointOfInterestID,OriginPointOfInterest.PointOfInterestName AS OriginPointOfInterestName,OriginPointOfInterest.Radius AS OriginPointOfInterestRadius,OriginPointOfInterest.Azimuth AS OriginPointOfInterestAngleX,OriginPointOfInterest.Inclination AS OriginPointOfInterestAngleY,DestinationPointOfInterest.PointOfInterestID AS DestinationPointOfInterestID,DestinationPointOfInterest.PointOfInterestName AS DestinationPointOfInterestName,DestinationPointOfInterest.Radius AS DestinationPointOfInterestRadius,DestinationPointOfInterest.Azimuth AS DestinationPointOfInterestAngleX,DestinationPointOfInterest.Inclination AS DestinationPointOfInterestAngleY  FROM Flight  LEFT JOIN Gate AS OriginGate  ON Flight.OriginGateID = OriginGate.GateID  LEFT JOIN Gate  AS DestinationGate  ON Flight.DestinationGateID = DestinationGate.GateID  LEFT JOIN Spaceship   ON Flight.SpaceshipID = Spaceship.SpaceshipID  LEFT JOIN Spaceport AS OriginSpaceport  ON OriginGate.SpaceportID = OriginSpaceport.SpaceportID  LEFT JOIN Spaceport AS DestinationSpaceport  ON DestinationGate.SpaceportID = DestinationSpaceport.SpaceportID  LEFT JOIN PointOfInterest AS OriginPointOfInterest  ON OriginSpaceport.PointOfInterestID = OriginPointOfInterest.PointOfInterestID  LEFT JOIN PointOfInterest AS DestinationPointOfInterest  ON DestinationSpaceport.PointOfInterestID = DestinationPointOfInterest.PointOfInterestID WHERE FlightID = @ID";

            using SqlCommand com = new(cmdText);

            com.Parameters.AddWithValue("@ID", id);

            DataTable dt = new();
            dt = Fetch(com);
            return new FlightDTO(
                        dt.Rows[0].Field<long>("FlightID"),
                        dt.Rows[0].Field<DateTime>("DepartureTime"),
                        dt.Rows[0].Field<long>("StatusFlight"),
                        dt.Rows[0].Field<string>("FlightNumber"),
                        new GateDTO(
                            dt.Rows[0].Field<long>("OriginGateID"),
                            dt.Rows[0].Field<string>("OriginGateName"),
                            new SpaceportDTO(
                                dt.Rows[0].Field<long>("OriginSpaceportID"),
                                dt.Rows[0].Field<string>("OriginSpaceportName"),
                                new PointOfInterestDTO(
                                    dt.Rows[0].Field<long>("OriginPointOfInterestID"),
                                    dt.Rows[0].Field<string>("OriginPointOfInterestName"),
                                    dt.Rows[0].Field<decimal>("OriginPointOfInterestRadius"),
                                    dt.Rows[0].Field<decimal>("OriginPointOfInterestAngleX"),
                                    dt.Rows[0].Field<decimal>("OriginPointOfInterestAngleY")
                                )
                            )
                        ),
                        new GateDTO(
                            dt.Rows[0].Field<long>("DestinationGateID"),
                            dt.Rows[0].Field<string>("DestinationGateName"),
                            new SpaceportDTO(
                                dt.Rows[0].Field<long>("DestinationSpaceportID"),
                                dt.Rows[0].Field<string>("DestinationSpaceportName"),
                                new PointOfInterestDTO(
                                    dt.Rows[0].Field<long>("DestinationPointOfInterestID"),
                                    dt.Rows[0].Field<string>("DestinationPointOfInterestName"),
                                    dt.Rows[0].Field<decimal>("DestinationPointOfInterestRadius"),
                                    dt.Rows[0].Field<decimal>("DestinationPointOfInterestAngleX"),
                                    dt.Rows[0].Field<decimal>("DestinationPointOfInterestAngleY")
                                )
                            )
                        ),
                        new SpaceshipDTO(
                            dt.Rows[0].Field<long>("SpaceshipID"),
                            dt.Rows[0].Field<string>("SpaceshipName"),
                            dt.Rows[0].Field<int>("Seat"),
                            dt.Rows[0].Field<decimal>("Speed"),
                            dt.Rows[0].Field<long>("SpaceshipRoleID")
                        )
                    )
;
        }

        public bool Insert(FlightDTO entity)
        {
            string cmdText = "INSERT INTO Flight (DepartureTime ,StatusFlight ,FlightNumber ,SpaceshipID ,OriginGateID ,DestinationGateID) VALUES (@DepartureTime, @StatusFlight, @FlightNumber, @SpaceshipID, @OriginGateID, @DestinationGateID)";

            using SqlCommand com = new(cmdText);
            com.Parameters.Add("@DepartureTime", SqlDbType.SmallDateTime).Value = entity.DepartureTime;
            com.Parameters.Add("@StatusFlight", SqlDbType.BigInt).Value = entity.Status;
            com.Parameters.Add("@FlightNumber", SqlDbType.NVarChar, 9).Value = entity.FlightNumber;
            com.Parameters.Add("@SpaceshipID", SqlDbType.BigInt).Value = entity.Spaceship.Id;
            com.Parameters.Add("@OriginGateID", SqlDbType.BigInt).Value = entity.OriginGate.Id;
            com.Parameters.Add("@DestinationGateID", SqlDbType.BigInt).Value = entity.DestinationGate.Id;

            return Persist(com);
        }

        public bool Update(FlightDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
