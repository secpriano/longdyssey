using IL.DTO;
using System.Data.SqlClient;
using System.Data;
using IL.Interface.DAL;

namespace DAL
{
    public class FlightDAL : Database, IFlightDAL
    {
        public bool Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            string cmdText = "SELECT * FROM Flight";

            using SqlCommand com = new(cmdText);

            return Fetch(com);

        }

        public FlightDTO GetById(ulong id)
        {
            throw new NotImplementedException();
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
