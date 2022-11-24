namespace LongdysseyWebApplication.Models.Admin.ScheduleModels
{
    public class SchedulePlannerModel
    {
        public SpaceshipModel Spaceship {  get; set; }
        List<PointOfInterestModel> PointOfInterests { get; set; }
        public SchedulePlannerModel(SpaceshipModel spaceship, List<PointOfInterestModel> pointOfInterests)
        {
            Spaceship = spaceship;
            PointOfInterests = pointOfInterests;
        }

        private void CalculateAllroutes()
        {
            List<List<PointOfInterestModel>> possibleRoutes = new List<List<PointOfInterestModel>>();
            List<PointOfInterestModel> possibleRoute = new List<PointOfInterestModel>();

            PointOfInterests.ForEach(pointOfInterest =>
            {
                if (pointOfInterest.Radius < 2.3m && pointOfInterest.Name != "Earth")
                {
                    possibleRoute.Add(pointOfInterest);
                }
            });
            for (int i = 0; i < possibleRoute.Count * possibleRoute.Count - 1; i++)
            {

            }
            possibleRoutes.Add(possibleRoute);

            PointOfInterestModel poi = possibleRoute[1];
            possibleRoute.RemoveAt(1);
            possibleRoute.Add(poi);
            possibleRoutes.Add(possibleRoute);
        }
    }
}
