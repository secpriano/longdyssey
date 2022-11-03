using BLL.Entity;
using System.Globalization;

namespace LongdysseyWebApplication.Models
{
    public class FlightViewModel
    {
        public List<Flight> Flights;
        public List<PointOfInterest> PointOfInterests;
        public List<string> pointOfInterestsX = new();
        public List<string> pointOfInterestsY = new();
        public List<string> PointOfInterestRadius = new();

        public FlightViewModel(List<Flight> flights, List<PointOfInterest> pointOfInterests)
        {
            Flights = flights;
            PointOfInterests = pointOfInterests;

            int zoom = 15;

            PointOfInterests.ForEach(poi =>
            {
                double X = poi.SphericalToCartesianCoordinates()[(byte)PointOfInterest.Coordinates.X] * zoom;
                double Y = poi.SphericalToCartesianCoordinates()[(byte)PointOfInterest.Coordinates.Y] * zoom;
                pointOfInterestsX.Add(ConvertToDot(X));
                pointOfInterestsY.Add(ConvertToDot(Y));

                int radius = (int)Math.Sqrt(Math.Pow(0 - X, 2) + Math.Pow(0 - Y, 2));
                int diameter = radius * 2;
                PointOfInterestRadius.Add(Convert.ToString(diameter, CultureInfo.GetCultureInfo("en-US")));
            });
        }

        private string ConvertToDot(double commaValue) => Convert.ToString(commaValue, CultureInfo.GetCultureInfo("en-US"));
    }
}
