using IL.DTO;
using IL.Interface.DAL;
using System.Data.SqlClient;
using System.Data;
using ExceptionHandler;

namespace DAL
{
    public class FlightScheduleDAL : Database, IFlightScheduleDAL
    {
        public FlightScheduleDTO GetByName(string name)
        {
            string cmdText = "SELECT * FROM FlightSchedule WHERE FlightScheduleName = @Name;";

            using SqlCommand com = new(cmdText);

            com.Parameters.AddWithValue("@Name", name);

            DataTable dt = new();
            dt = Fetch(com);
            return new FlightScheduleDTO(
                dt.Rows[0].Field<long>("FlightScheduleID"),
                dt.Rows[0].Field<string>("FlightScheduleName"),
                dt.Rows[0].Field<DateTime>("StartDate"),
                dt.Rows[0].Field<DateTime>("EndDate")
            );
        }

        public bool Insert(FlightScheduleDTO flightSchedule)
        {
            string cmdText = "SELECT * FROM FlightSchedule WHERE (@StartDate <= EndDate AND @EndDate >= StartDate)";
            
            using SqlCommand com = new(cmdText);

            com.Parameters.AddWithValue("@StartDate", flightSchedule.StartDate);
            com.Parameters.AddWithValue("@EndDate", flightSchedule.EndDate);

            DataTable dt = new();
            dt = Fetch(com);
            if (dt.Rows.Count == 0)
            {
                throw new DALexception(ErrorType.FlightScheduleDatesOverlap , "The dates overlap with another flight schedule");
            }

            string cmdTextInsert = "INSERT INTO FlightSchedule (FlightScheduleName, StartDate, EndDate) VALUES (@Name, @StartDate, @EndDate)";

            using SqlCommand comInsert = new(cmdTextInsert);

            comInsert.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = flightSchedule.Name;
            comInsert.Parameters.Add("@StartDate", SqlDbType.SmallDateTime).Value = flightSchedule.StartDate;
            comInsert.Parameters.Add("@EndDate", SqlDbType.SmallDateTime).Value = flightSchedule.EndDate;
            
            Persist(comInsert);
            return true;
        }
    }
}
