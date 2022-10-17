using IL.DTO;
using System.Data.SqlClient;
using System.Data;
using IL.Interface.DAL;

namespace DAL
{
    public class PointOfInterestDAL : Database, IPointOfInterestDAL
    {
        public List<PointOfInterestDTO> GetAll()
        {
            string cmdText = "SELECT * FROM PointOfInterest";

            using SqlCommand com = new(cmdText);

            DataTable dt = new();
            dt = Fetch(com);

            List<PointOfInterestDTO> DTOs = new();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTOs.Add(
                    new PointOfInterestDTO(
                        dt.Rows[i].Field<long>("PointOfInterestID"),
                        dt.Rows[i].Field<string>("PointOfInterestName"),
                        dt.Rows[i].Field<decimal>("Radius"),
                        dt.Rows[i].Field<decimal>("Azimuth"),
                        dt.Rows[i].Field<decimal>("Inclination")
                    )
                );
            }

            return DTOs;
        }
    }
}
