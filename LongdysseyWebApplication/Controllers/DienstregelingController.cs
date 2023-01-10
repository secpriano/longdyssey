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
        //private readonly FlightContainer flightController = new(new FlightDAL());

        // GET: DienstregelingController
        public ActionResult Index()
        {
            DienstregelingViewModel dienstregelingViewModel = new(GetAllAO());

            return View(dienstregelingViewModel);
        }

        private List<AstronomicalObjectModel> GetAllAO() => astronomicalObjectContainer.GetAll().Select(AO => new AstronomicalObjectModel(AO.Id, AO.Name, AO.Radius, AO.Azimuth, AO.Inclination, AO.OrbitalSpeed)).ToList();

        public ActionResult GenerateFlightSchedule()
        {
            string name = "beste algo schedule naam";
            Spaceship spaceship = new(2, "Saggitarius", 4895, 0.2M, 2);
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(30);

            ShortestRoute SR = new(spaceship, astronomicalObjectContainer.GetAll(), startDate);
            List<AstronomicalObject> Route = SR.CalculateBestRoute(0);
            Algorithm.FlightSchedule FS = new(name, spaceship, Route, startDate, endDate);

            return RedirectToAction("Index");
        }
    }
}
