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
