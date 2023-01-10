using IL.DTO;
using IL.Interface.DAL;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class GateDAL : Database, IGateDAL
    {
        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GateDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public GateDTO GetByAstronomicalObjectName(string name)
        {
            string cmdText = "SELECT TOP 1 * FROM AstronomicalObject JOIN Spaceport ON Spaceport.AstronomicalObjectID = AstronomicalObject.AstronomicalObjectID JOIN Gate ON Gate.SpaceportID = Spaceport.SpaceportID  WHERE AstronomicalObjectName = @Name";

            using SqlCommand com = new(cmdText);

            com.Parameters.AddWithValue("@Name", name);

            DataTable dt = new();
            dt = Fetch(com);
            return new GateDTO(
                dt.Rows[0].Field<long>("GateID"),
                dt.Rows[0].Field<string>("GateName"),
                new SpaceportDTO(
                    dt.Rows[0].Field<long>("SpaceportID"),
                    dt.Rows[0].Field<string>("SpaceportName"),
                    new AstronomicalObjectDTO(
                        dt.Rows[0].Field<long>("AstronomicalObjectID"),
                        dt.Rows[0].Field<string>("AstronomicalObjectName"),
                        dt.Rows[0].Field<decimal>("Radius"),
                        dt.Rows[0].Field<decimal>("Azimuth"),
                        dt.Rows[0].Field<decimal>("Inclination"),
                        dt.Rows[0].Field<decimal>("OrbitalSpeed")
                    )
                )
            );
        }

        public GateDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public List<GateDTO> GetBySpaceportId(long id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(GateDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(GateDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
