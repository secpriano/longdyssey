using Algorithm;
using BLL.Container;
using BLL.Entity;
using DAL;
using LongdysseyWebApplication.Models.Dienstregeling;
using Microsoft.AspNetCore.Mvc;

namespace LongdysseyWebApplication.Controllers
{
    public class DienstregelingController : Controller
    {
        private readonly AstronomicalObjectContainer astronomicalObjectContainer = new(new AstronomicalObjectDAL());
        private readonly FlightContainer flightController = new(new FlightDAL());

        // GET: DienstregelingController
        public ActionResult Index()
        {
            DienstregelingViewModel dienstregelingViewModel = new(GetAllAO());

            return View(dienstregelingViewModel);
        }

        private List<AstronomicalObjectModel> GetAllAO() => astronomicalObjectContainer.GetAll().Select(AO => new AstronomicalObjectModel(AO.Id, AO.Name, AO.Radius, AO.Azimuth, AO.Inclination, AO.OrbitalSpeed)).ToList();

        public ActionResult GenerateFlightSchedule()
        {
            FlightScheduler fs = new(new(1, "Longdyssey A380", 380, 0.2M, 1), astronomicalObjectContainer.GetAll(), DateTime.Now);
            List<AstronomicalObject> Route = fs.CalculateBestRoute(0);

            ///Algorithm bedenken +1 +1?
            //int[] distances = { };

            decimal speed = fs.Spaceship.Speed;

            decimal[] travelTimes = new decimal[Route.Count - 1];
            for (int i = 0; i < Route.Count - 1; i++)
            {
                //travelTimes[i] = distances[i] / (decimal)speed;
            }

            /// Start datum
            DateTime departureTime = DateTime.Now;

            List<DateTime> departures = new();

            departures.Add(departureTime);

            for (int i = 0; i < Route.Count - 1; i++)
            {
                departureTime = departureTime.AddHours((double)travelTimes[i]);
                departures.Add(departureTime);
            }

            /// SQL
            for (int i = 0; i < Route.Count; i++)
            {
                //flightController.Add(new(departures[i], 1, departures[i], departures[i + 1], fs.Spaceship));
            }

            return View();
        }
    }
}
