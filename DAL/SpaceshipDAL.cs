using IL.DTO;
using IL.Interface.DAL;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class SpaceshipDAL : Database, ISpaceshipDAL
    {
        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpaceshipDTO> GetAll()
        {
            string cmdText = "SELECT * FROM Spaceship";

            using SqlCommand com = new(cmdText);

            DataTable dt = new();
            dt = Fetch(com);

            List<SpaceshipDTO> DTOs = new();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTOs.Add(
                    new SpaceshipDTO(
                        dt.Rows[i].Field<long>("SpaceshipID"),
                        dt.Rows[i].Field<string>("SpaceshipName"),
                        dt.Rows[i].Field<int>("Seat"),
                        dt.Rows[i].Field<decimal>("Speed"),
                        dt.Rows[i].Field<long>("SpaceshipRoleID")
                    )
                );
            }

            return DTOs;
        }

        public SpaceshipDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SpaceshipDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SpaceshipDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
