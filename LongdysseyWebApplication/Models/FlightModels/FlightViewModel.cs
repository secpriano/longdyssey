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
        public List<AstronomicalObject> AstronomicalObjects;
        public List<string> AstronomicalObjectX = new();
        public List<string> AstronomicalObjectY = new();
        public List<string> AstronomicalObjectRadius = new();

        private long originAO;
        public string OriginAO
        {
            get => originAO.ToString();
            set
            {
                SpaceportContainer sc = new(new SpaceportSTUB());
                sc.GetAll().ForEach(spaceport =>
                {
                    if (value == $"{spaceport.AstronomicalObject.Name} | {spaceport.Name}")
                    {
                        originAO = spaceport.Id;
                    }
                });
            }
        }
        private long destinationAO;
        public string DestinationAO
        {
            get => destinationAO.ToString();
            set
            {
                SpaceportContainer sc = new(new SpaceportSTUB());
                sc.GetAll().ForEach(spaceport =>
                {
                    if (value == $"{spaceport.AstronomicalObject.Name} | {spaceport.Name}")
                    {
                        destinationAO = spaceport.Id;
                    }
                });
            }
        }
        public DateTime LeaveDate { get; set; }
        public long Travelers { get; set; }

        // Format AO Spaceport

        public FlightViewModel(List<AstronomicalObject> astronomicalObjects, List<Spaceport> spaceports)
        {
            AstronomicalObjects = astronomicalObjects;
            Spaceports = spaceports;

            int zoom = 15;

            AstronomicalObjects.ForEach(AO =>
            {
                double X = AO.SphericalToCartesianCoordinates()[(byte)AstronomicalObject.Coordinates.X] * zoom;
                double Y = AO.SphericalToCartesianCoordinates()[(byte)AstronomicalObject.Coordinates.Y] * zoom;
                AstronomicalObjectX.Add(ConvertToDot(X));
                AstronomicalObjectY.Add(ConvertToDot(Y));

                int radius = (int)Math.Sqrt(Math.Pow(0 - X, 2) + Math.Pow(0 - Y, 2));
                int diameter = radius * 2;
                AstronomicalObjectRadius.Add(Convert.ToString(diameter, CultureInfo.GetCultureInfo("en-US")));
            });
        }

        public FlightViewModel()
        {

        }

        private string ConvertToDot(double commaValue) => Convert.ToString(commaValue, CultureInfo.GetCultureInfo("en-US"));
    }
}
