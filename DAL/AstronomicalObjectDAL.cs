using IL.DTO;
using System.Data.SqlClient;
using System.Data;
using IL.Interface.DAL;

namespace DAL
{
    public class AstronomicalObjectDAL : Database, IAstronomicalObjectDAL
    {
        public List<AstronomicalObjectDTO> GetAll()
        {
            string cmdText = "EXEC GetAllAstronomicalObjects";

            using SqlCommand com = new(cmdText);

            DataTable dt = new();
            dt = Fetch(com);

            List<AstronomicalObjectDTO> DTOs = new();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTOs.Add(
                    new AstronomicalObjectDTO(
                        dt.Rows[i].Field<long>("AstronomicalObjectID"),
                        dt.Rows[i].Field<string>("AstronomicalObjectName"),
                        dt.Rows[i].Field<decimal>("Radius"),
                        dt.Rows[i].Field<decimal>("Azimuth"),
                        dt.Rows[i].Field<decimal>("Inclination"),
                        dt.Rows[i].Field<decimal>("OrbitalSpeed")
                    )
                );
            }

            return DTOs;
        }
    }
}
