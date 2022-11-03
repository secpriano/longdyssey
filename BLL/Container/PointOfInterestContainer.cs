using BLL.Entity;
using IL.Interface.DAL;

namespace BLL.Container
{
    public class PointOfInterestContainer
    {
        private readonly IPointOfInterestDAL Db;

        public PointOfInterestContainer(IPointOfInterestDAL db)
        {
            Db = db;
        }

        public List<PointOfInterest> GetAll()
        {
            List<PointOfInterest> pointOfInterests = new();

            Db.GetAll().ForEach(pointOfInterestDTO =>
            {
                pointOfInterests.Add(new(pointOfInterestDTO));
            });

            return pointOfInterests;
        }
    }
}
