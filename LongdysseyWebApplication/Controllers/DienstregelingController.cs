using Algorithm;
using BLL.Container;
using BLL.Entity;
using DAL;
using WebApplication.Models.Dienstregeling;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models.SpaceshipModels;
using ExceptionHandler;

namespace WebApplication.Controllers
{
    public class DienstregelingController : Controller
    {
        private readonly AstronomicalObjectContainer astronomicalObjectContainer = new(new AstronomicalObjectDAL());
        private readonly SpaceshipContainer spaceshipContainer = new(new SpaceshipDAL());

        // GET: DienstregelingController
        public ActionResult Index()
        {
            try
            {
                DienstregelingViewModel dienstregelingViewModel = new(GetAllAstronomicalObjects(), GetAllSpaceships());

                return View(dienstregelingViewModel);
            }
            catch (ErrorResponse e)
            {
                return RedirectToAction("Index", "Error", new { errorMessage = e.Message });
            }
        }

        private List<AstronomicalObjectModel> GetAllAstronomicalObjects()
        {
            return astronomicalObjectContainer.GetAll().Select(AO =>
            new AstronomicalObjectModel(
                AO.Id,
                AO.Name,
                AO.Radius,
                AO.Azimuth,
                AO.Inclination,
                AO.OrbitalSpeed)
            ).ToList();
        }
        private List<SpaceshipModel> GetAllSpaceships()
        {
            return spaceshipContainer.GetAll().Select(spaceship => 
            new SpaceshipModel(
                spaceship.Id, 
                spaceship.Name, 
                spaceship.Seat, 
                spaceship.Speed, 
                spaceship.Role)
            ).ToList();
        }

        public ActionResult GenerateFlightSchedule(DienstregelingViewModel dienstregelingViewModel)
        {
            try
            {
                ShortestRoute shortestRoute = new(new SpaceshipDAL(), dienstregelingViewModel.SpaceshipName, new AstronomicalObjectDAL(), dienstregelingViewModel.StartDate);
                List<AstronomicalObject> Route = shortestRoute.CalculateBestRoute();
                
                FlightScheduler flightScheduler = new(new GateDAL(), new FlightScheduleDAL(), new FlightDAL());
                flightScheduler.InsertFlightSchedule(dienstregelingViewModel.Name, dienstregelingViewModel.StartDate, dienstregelingViewModel.EndDate);
                FlightSchedule flightSchedule = flightScheduler.GetByName(dienstregelingViewModel.Name);
                flightScheduler.GenerateFlightsFromFlightSchedule(new SpaceshipDAL(), flightSchedule, dienstregelingViewModel.SpaceshipName, Route);
                
                return RedirectToAction("Index");
            }
            catch (ErrorResponse e)
            {
                return RedirectToAction("Index", "Error", new { errorMessage = e.Message });
            }
        }
    }
}
