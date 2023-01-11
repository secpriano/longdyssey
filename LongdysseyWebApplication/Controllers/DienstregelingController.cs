using Algorithm;
using BLL.Container;
using BLL.Entity;
using DAL;
using LongdysseyWebApplication.Models.Dienstregeling;
using Microsoft.AspNetCore.Mvc;
using LongdysseyWebApplication.Models.SpaceshipModels;

namespace LongdysseyWebApplication.Controllers
{
    public class DienstregelingController : Controller
    {
        private readonly AstronomicalObjectContainer astronomicalObjectContainer = new(new AstronomicalObjectDAL());
        private readonly SpaceshipContainer spaceshipContainer = new(new SpaceshipDAL());

        // GET: DienstregelingController
        public ActionResult Index()
        {
            DienstregelingViewModel dienstregelingViewModel = new(GetAllAO(), GetAllSpaceships());

            return View(dienstregelingViewModel);
        }

        private List<AstronomicalObjectModel> GetAllAO() => astronomicalObjectContainer.GetAll().Select(AO => new AstronomicalObjectModel(AO.Id, AO.Name, AO.Radius, AO.Azimuth, AO.Inclination, AO.OrbitalSpeed)).ToList();
        private List<SpaceshipModel> GetAllSpaceships() => spaceshipContainer.GetAll().Select(spaceship => new SpaceshipModel(spaceship.Id, spaceship.Name, spaceship.Seat, spaceship.Speed, spaceship.Role)).ToList();

        public ActionResult GenerateFlightSchedule(DienstregelingViewModel dienstregelingViewModel)
        {
            Spaceship selectedSpaceship = new();
            spaceshipContainer.GetAll().ForEach(spaceship =>
            {
                if (dienstregelingViewModel.SpaceshipName == spaceship.Name)
                {
                    selectedSpaceship = spaceship; 
                }
            });

            ShortestRoute SR = new(selectedSpaceship, astronomicalObjectContainer.GetAll(), dienstregelingViewModel.StartDate);
            List<AstronomicalObject> Route = SR.CalculateBestRoute(0);
            Algorithm.FlightSchedule FS = new(dienstregelingViewModel.Name, selectedSpaceship, Route, dienstregelingViewModel.StartDate, dienstregelingViewModel.EndDate);

            return RedirectToAction("Index");
        }
    }
}
