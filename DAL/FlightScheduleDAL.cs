using IL.DTO;
using IL.Interface.DAL;
using System.Data.SqlClient;
using System.Data;

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
            string cmdText = "INSERT INTO FlightSchedule (FlightScheduleName, StartDate, EndDate) VALUES (@Name, @StartDate, @EndDate)";

            using SqlCommand com = new(cmdText);

            com.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = flightSchedule.Name;
            com.Parameters.Add("@StartDate", SqlDbType.SmallDateTime).Value = flightSchedule.StartDate;
            com.Parameters.Add("@EndDate", SqlDbType.SmallDateTime).Value = flightSchedule.EndDate;

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
    }
}
