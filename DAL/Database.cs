using System.Data;
using System.Data.SqlClient;
using System.Security;
namespace DAL
{
    public class Database
    {
        SqlConnection? con;
        SecureString? securePass;
        private readonly string connectionString = "Server=mssqlstud.fhict.local;Database=dbi484972;";
        private readonly string userId = "dbi484972";
        private readonly string password = "1835long";

        private SecureString SecurePass(string pass)
        {
            unsafe
            {
                fixed (char* value = pass)
                {
                    return securePass = new(value, 8);
                }
            }
        }

        private SqlCommand PrepareQuery(SqlCommand com)
        {
            SqlCredential credential = new(userId, SecurePass(password));
            con = new(connectionString, credential);
            con.Open();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.Prepare();
            return com;
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
