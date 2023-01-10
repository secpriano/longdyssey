namespace LongdysseyWebApplication.Models.Admin.ScheduleModels
{
    public class SchedulePlannerModel
    {
        public SpaceshipModel Spaceship { get; set; }
        List<AstronomicalObjectModel> PointOfInterests { get; set; }
        public SchedulePlannerModel(SpaceshipModel spaceship, List<AstronomicalObjectModel> pointOfInterests)
        {
            Spaceship = spaceship;
            PointOfInterests = pointOfInterests;
        }

        private void CalculateAllroutes()
        {
            List<List<AstronomicalObjectModel>> possibleRoutes = new List<List<AstronomicalObjectModel>>();
            List<AstronomicalObjectModel> possibleRoute = new List<AstronomicalObjectModel>();

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

            AstronomicalObjectModel poi = possibleRoute[1];
            possibleRoute.RemoveAt(1);
            possibleRoute.Add(poi);
            possibleRoutes.Add(possibleRoute);
        }
    }
}
