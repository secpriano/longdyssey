using System.Data;
using System.Data.SqlClient;
using System.Security;
namespace DAL
{
    public class Database
    {
        SqlConnection? con;
        private readonly string connectionString = "Server=mssqlstud.fhict.local;Database=dbi484972;User Id=dbi484972;Password=1835long;";

        private SqlCommand PrepareQuery(SqlCommand com)
        {
            try
            {
                con = new(connectionString);
                con.Open();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                return com;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Persist(SqlCommand com)
        {
            switch (PrepareQuery(com).ExecuteNonQuery())
            {
                case > 0:
                    con?.Close();
                    return true;
                default:
                    con?.Close();
                    return false;
            }
        }

        public DataTable Fetch(SqlCommand com)
        {
            using SqlDataAdapter sqlDataAdapter = new(PrepareQuery(com));
            using DataTable dt = new();
            sqlDataAdapter.Fill(dt);
            con?.Close();
            return dt;
        }
    }
}
