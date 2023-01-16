using BLL.Entity;
using ExceptionHandler;
using IL.Interface.DAL;

namespace BLL.Container
{
    public class AstronomicalObjectContainer
    {
        private readonly IAstronomicalObjectDAL Db;

        public AstronomicalObjectContainer(IAstronomicalObjectDAL db)
        {
            Db = db;
        }

        public List<AstronomicalObject> GetAll()
        {
            try
            {
                return Db.GetAll().Select(astronomicalObjectDTO => new AstronomicalObject(astronomicalObjectDTO)).ToList();
            }
            catch (DALexception e)
            {
                throw new ErrorResponse(e.ErrorType);
            }
        }
    }
}
