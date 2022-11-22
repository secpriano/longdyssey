using BLL.Container;
using BLL.Entity;
using System.Globalization;
using Test.STUB;

namespace LongdysseyWebApplication.Models.FlightModels
{
    public class FlightViewModel
    {
        public List<Flight> Flights = new();
        public List<Spaceport> Spaceports;
        public List<PointOfInterest> PointOfInterests;
        public List<string> pointOfInterestsX = new();
        public List<string> pointOfInterestsY = new();
        public List<string> PointOfInterestRadius = new();

        private long originPOI;
        public string OriginPOI
        {
            get => originPOI.ToString();
            set
            {
                SpaceportContainer sc = new(new SpaceportSTUB());
                sc.GetAll().ForEach(spaceport =>
                {
                    if (value == $"{spaceport.PointOfInterest.Name} | {spaceport.Name}")
                    {
                        originPOI = spaceport.Id;
                    }
                });
            }
        }
        private long destinationPOI;
        public string DestinationPOI
        {
            get => destinationPOI.ToString();
            set
            {
                SpaceportContainer sc = new(new SpaceportSTUB());
                sc.GetAll().ForEach(spaceport =>
                {
                    if (value == $"{spaceport.PointOfInterest.Name} | {spaceport.Name}")
                    {
                        destinationPOI = spaceport.Id;
                    }
                });
            }
        }
        public DateTime LeaveDate { get; set; }
        public long Travelers { get; set; }

        // Format POI Spaceport

        public FlightViewModel(List<PointOfInterest> pointOfInterests, List<Spaceport> spaceports)
        {
            PointOfInterests = pointOfInterests;
            Spaceports = spaceports;

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

        public FlightViewModel()
        {

        }

        private string ConvertToDot(double commaValue) => Convert.ToString(commaValue, CultureInfo.GetCultureInfo("en-US"));
    }
}
