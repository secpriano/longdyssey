using BLL.Container;
using DAL;
using System.Globalization;

namespace LongdysseyWebApplication.Models
{
    public class FlightSearchViewModel
    {
        public List<FlightModel> Flights { get; set; } = new List<FlightModel>();
        public List<SpaceportModel> Spaceports { get; set; }
        public List<AstronomicalObjectModel> AstronomicalObjects { get; set; }

        public List<string> AstronomicalObjectX = new();
        public List<string> AstronomicalObjectY = new();
        public List<string> AstronomicalObjectRadius = new();

        public string OriginAOandSpaceportName { get; set; }
        public string DestinationAOandSpaceportName { get; set; }
        public DateTime LeaveDate { get; set; }
        public long Travelers { get; set; }

        // Format AO Spaceport

        public FlightSearchViewModel(List<AstronomicalObjectModel> astronomicalObjects, List<SpaceportModel> spaceports)
        {
            AstronomicalObjects = astronomicalObjects;
            Spaceports = spaceports;

            int zoom = 15;

            AstronomicalObjects.ForEach(AO =>
            {
                double X = AO.SphericalToCartesianCoordinates()[(byte)AstronomicalObjectModel.Coordinates.X] * zoom;
                double Y = AO.SphericalToCartesianCoordinates()[(byte)AstronomicalObjectModel.Coordinates.Y] * zoom;
                AstronomicalObjectX.Add(ConvertToDot(X));
                AstronomicalObjectY.Add(ConvertToDot(Y));

                int radius = (int)Math.Sqrt(Math.Pow(0 - X, 2) + Math.Pow(0 - Y, 2));
                int diameter = radius * 2;
                AstronomicalObjectRadius.Add(ConvertToDot(diameter));
            });
        }

        public FlightSearchViewModel()
        {

        }

        private string ConvertToDot(double commaValue) => Convert.ToString(commaValue, CultureInfo.GetCultureInfo("en-US"));
    }
}
