using IL.DTO;
using System.Data.SqlClient;
using System.Data;
using IL.Interface.DAL;
using ExceptionHandler;

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
            string cmdText = "EXEC GetAllFlights";

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
                                new AstronomicalObjectDTO(
                                    dt.Rows[i].Field<long>("OriginAstronomicalObjectID"),
                                    dt.Rows[i].Field<string>("OriginAstronomicalObjectName"),
                                    dt.Rows[i].Field<decimal>("OriginAstronomicalObjectRadius"),
                                    dt.Rows[i].Field<decimal>("OriginAstronomicalObjectAzimuth"),
                                    dt.Rows[i].Field<decimal>("OriginAstronomicalObjectInclination"),
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
                                    dt.Rows[i].Field<decimal>("DestinationAstronomicalObjectAzimuth"),
                                    dt.Rows[i].Field<decimal>("DestinationAstronomicalObjectInclination"),
                                    dt.Rows[i].Field<decimal>("DestinationAstronomicalObjectOrbitalSpeed")
                                )
                            )
                        ), 
                        new SpaceshipDTO(
                            dt.Rows[i].Field<long>("SpaceshipID"),
                            dt.Rows[i].Field<string>("SpaceshipName"),
                            dt.Rows[i].Field<int>("Seat"),
                            dt.Rows[i].Field<decimal>("Speed"),
                            dt.Rows[i].Field<long>("SpaceshipRoleID")
                        ),
                        null
                    )
                );
            }

            return DTOs;
        }

        public List<FlightDTO> SearchFlights(DateTime leaveDate, long originGate, long destinationGate, long amountSeats)
        {
            string cmdText = "EXEC SearchFlight @LeaveDate, @MaxTime, @OriginGate, @DestinationGate, @Travelers";

            using SqlCommand com = new(cmdText);

            com.Parameters.AddWithValue("@LeaveDate", leaveDate);

            TimeSpan oneDayInHours = new(23, 59, 0);
            DateTime maxTime = leaveDate.Date + oneDayInHours;

            com.Parameters.AddWithValue("@MaxTime", maxTime);
            com.Parameters.AddWithValue("@OriginGate", originGate);
            com.Parameters.AddWithValue("@DestinationGate", destinationGate);
            com.Parameters.AddWithValue("@Travelers", amountSeats);

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
                                new AstronomicalObjectDTO(
                                    dt.Rows[i].Field<long>("OriginAstronomicalObjectID"),
                                    dt.Rows[i].Field<string>("OriginAstronomicalObjectName"),
                                    dt.Rows[i].Field<decimal>("OriginAstronomicalObjectRadius"),
                                    dt.Rows[i].Field<decimal>("OriginAstronomicalObjectAzimuth"),
                                    dt.Rows[i].Field<decimal>("OriginAstronomicalObjectInclination"),
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
                                    dt.Rows[i].Field<decimal>("DestinationAstronomicalObjectAzimuth"),
                                    dt.Rows[i].Field<decimal>("DestinationAstronomicalObjectInclination"),
                                    dt.Rows[i].Field<decimal>("DestinationAstronomicalObjectOrbitalSpeed")
                                )
                            )
                        ), 
                        new SpaceshipDTO(
                            dt.Rows[i].Field<long>("SpaceshipID"),
                            dt.Rows[i].Field<string>("SpaceshipName"),
                            dt.Rows[i].Field<int>("Seat"),
                            dt.Rows[i].Field<decimal>("Speed"),
                            dt.Rows[i].Field<long>("SpaceshipRoleID")
                        ),
                        new FlightScheduleDTO(
                            dt.Rows[i].IsNull("FlightScheduleID") ? (long?)null : dt.Rows[i].Field<long>("FlightScheduleID"),
                            dt.Rows[i].IsNull("FlightScheduleName") ? (string?)null : dt.Rows[i].Field<string>("FlightScheduleName"),
                            dt.Rows[i].IsNull("StartDate") ? (DateTime?)null : dt.Rows[i].Field<DateTime>("StartDate"),
                            dt.Rows[i].IsNull("EndDate") ? (DateTime?)null : dt.Rows[i].Field<DateTime>("EndDate")
                        )
                    )
                );
            }
            if (DTOs.Count == 0)
            {
                throw new DALexception(ErrorType.FlightsAreEmpty ,"No flights found");
            }
            return DTOs;
        }

        public FlightDTO GetById(long id)
        {
            string cmdText = "EXEC GetFlightByID @FlightID";

            using SqlCommand com = new(cmdText);

            com.Parameters.AddWithValue("@FlightID", id);

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
                                new AstronomicalObjectDTO(
                                    dt.Rows[0].Field<long>("OriginAstronomicalObjectID"),
                                    dt.Rows[0].Field<string>("OriginAstronomicalObjectName"),
                                    dt.Rows[0].Field<decimal>("OriginAstronomicalObjectRadius"),
                                    dt.Rows[0].Field<decimal>("OriginAstronomicalObjectAzimuth"),
                                    dt.Rows[0].Field<decimal>("OriginAstronomicalObjectInclination"),
                                    dt.Rows[0].Field<decimal>("OriginAstronomicalObjectOrbitalSpeed")
                                )
                            )
                        ),
                        new GateDTO(
                            dt.Rows[0].Field<long>("DestinationGateID"),
                            dt.Rows[0].Field<string>("DestinationGateName"),
                            new SpaceportDTO(
                                dt.Rows[0].Field<long>("DestinationSpaceportID"),
                                dt.Rows[0].Field<string>("DestinationSpaceportName"),
                                new AstronomicalObjectDTO(
                                    dt.Rows[0].Field<long>("DestinationAstronomicalObjectID"),
                                    dt.Rows[0].Field<string>("DestinationAstronomicalObjectName"),
                                    dt.Rows[0].Field<decimal>("DestinationAstronomicalObjectRadius"),
                                    dt.Rows[0].Field<decimal>("DestinationAstronomicalObjectAzimuth"),
                                    dt.Rows[0].Field<decimal>("DestinationAstronomicalObjectInclination"),
                                    dt.Rows[0].Field<decimal>("DestinationAstronomicalObjectOrbitalSpeed")
                                )
                            )
                        ),
                        new SpaceshipDTO(
                            dt.Rows[0].Field<long>("SpaceshipID"),
                            dt.Rows[0].Field<string>("SpaceshipName"),
                            dt.Rows[0].Field<int>("Seat"),
                            dt.Rows[0].Field<decimal>("Speed"),
                            dt.Rows[0].Field<long>("SpaceshipRoleID")
                        ),
                        null
                    );
        }

        public List<FlightDTO> GetByFlightScheduleId(long id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(FlightDTO flight)
        {
            string cmdText = "INSERT INTO Flight (DepartureTime ,StatusFlight ,FlightNumber ,SpaceshipID ,OriginGateID ,DestinationGateID, FlightScheduleID) VALUES (@DepartureTime, @StatusFlight, @FlightNumber, @SpaceshipID, @OriginGateID, @DestinationGateID, @FlightScheduleID)";

            using SqlCommand com = new(cmdText);
            com.Parameters.Add("@DepartureTime", SqlDbType.SmallDateTime).Value = flight.DepartureTime;
            com.Parameters.Add("@StatusFlight", SqlDbType.BigInt).Value = flight.Status;
            com.Parameters.Add("@FlightNumber", SqlDbType.NVarChar, 9).Value = flight.FlightNumber;
            com.Parameters.Add("@SpaceshipID", SqlDbType.BigInt).Value = flight.Spaceship.Id;
            com.Parameters.Add("@OriginGateID", SqlDbType.BigInt).Value = flight.OriginGate.Id;
            com.Parameters.Add("@DestinationGateID", SqlDbType.BigInt).Value = flight.DestinationGate.Id;
            com.Parameters.Add("@FlightScheduleID", SqlDbType.BigInt).Value = flight.FlightSchedule.Id;

            try
            {
                Persist(com);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool Update(FlightDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool InsertFlightsFromFlightSchedule(List<FlightDTO> flights)
        {
            string cmdText = "INSERT INTO Flight (DepartureTime ,StatusFlight ,FlightNumber ,SpaceshipID ,OriginGateID ,DestinationGateID, FlightScheduleID) VALUES (@DepartureTime, @StatusFlight, @FlightNumber, @SpaceshipID, @OriginGateID, @DestinationGateID, @FlightScheduleID)";

            using SqlCommand com = new(cmdText);

            foreach (FlightDTO flight in flights)
            {
                com.Parameters.Clear();

                com.Parameters.Add("@DepartureTime", SqlDbType.SmallDateTime).Value = flight.DepartureTime;
                com.Parameters.Add("@StatusFlight", SqlDbType.BigInt).Value = flight.Status;
                com.Parameters.Add("@FlightNumber", SqlDbType.NVarChar, 9).Value = flight.FlightNumber;
                com.Parameters.Add("@SpaceshipID", SqlDbType.BigInt).Value = flight.Spaceship.Id;
                com.Parameters.Add("@OriginGateID", SqlDbType.BigInt).Value = flight.OriginGate.Id;
                com.Parameters.Add("@DestinationGateID", SqlDbType.BigInt).Value = flight.DestinationGate.Id;
                com.Parameters.Add("@FlightScheduleID", SqlDbType.BigInt).Value = flight.FlightSchedule.Id;

                try
                {
                    Persist(com);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }
    }
}
