using IL.DTO;
using IL.Interface.DAL;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class SpaceportDAL : Database, ISpaceportDAL
    {
        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpaceportDTO> GetAll()
        {
            string cmdText = "SELECT * FROM Spaceport JOIN AstronomicalObject ON AstronomicalObject.AstronomicalObjectID = Spaceport.AstronomicalObjectID";

            using SqlCommand com = new(cmdText);

            DataTable dt = new();
            dt = Fetch(com);

            List<SpaceportDTO> DTOs = new();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTOs.Add(
                    new SpaceportDTO(
                        dt.Rows[i].Field<long>("SpaceportID"),
                        dt.Rows[i].Field<string>("SpaceportName"),
                        new AstronomicalObjectDTO(
                            dt.Rows[i].Field<long>("AstronomicalObjectID"),
                            dt.Rows[i].Field<string>("AstronomicalObjectName"),
                            dt.Rows[i].Field<decimal>("Radius"),
                            dt.Rows[i].Field<decimal>("Azimuth"),
                            dt.Rows[i].Field<decimal>("Inclination"),
                            dt.Rows[i].Field<decimal>("OrbitalSpeed")
                        )
                    )
                );
            }

            return DTOs;
        }

        public SpaceportDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SpaceportDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SpaceportDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
