using BLL.Container;
using BLL.Entity;
using DAL;
using WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using ExceptionHandler;

namespace WebApplication.Controllers
{
    public class FlightController : Controller
    {
        private readonly FlightContainer flightContainer = new(new FlightDAL());
        private readonly AstronomicalObjectContainer astronomicalObjectContainer = new(new AstronomicalObjectDAL());
        private readonly SpaceportContainer spaceportContainer = new(new SpaceportDAL());

        // GET: FlightController
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                FlightSearchViewModel flightSearchViewModel = new(GetAllAstronomicalObjects(), GetAllSpaceport());
                return View(flightSearchViewModel);
            }
            catch (ErrorResponse e)
            {
                return RedirectToAction("Index", "Error", new { errorMessage = e.Message });
            }
        }

        // GET: FlightController/Detail/5
        [HttpGet]
        public ActionResult Detail(int id)
        {
            try
            {
                Flight flight = flightContainer.GetByID(id);
                flight.BoardingpassDb = new BoardingpassDAL();
                List<Boardingpass> boardingpasses = flight.GetBoardingpassesByFlightId();
                List<long> availableSeats = new();
                List<long> reservedSeats = new();

                boardingpasses.ForEach(boardingpass =>
                {
                    reservedSeats.Add(boardingpass.Seat);
                });

                for (int i = 1; i <= flight.Spaceship.Seat; i++)
                {
                    if (!reservedSeats.Contains(i))
                    {
                        availableSeats.Add(i);
                    }
                }
                
                ModelState.Clear();
                var errorMessage = TempData["ErrorMessage"] as string;
                
                FlightDetailViewModel flightDetailViewModel = new(flight, availableSeats);
                flightDetailViewModel.ErrorMessage = errorMessage;
                return View(flightDetailViewModel);
            }
            catch (ErrorResponse e)
            {
                return RedirectToAction("Index", "Error", new { errorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult BookSeat(FlightDetailViewModel flightDetailViewModel)
        {
            try
            {
                Flight.BookSeat(new BoardingpassDAL(), flightDetailViewModel.BookFlightId, flightDetailViewModel.SelectedSeat, 1);
                return RedirectToAction("Index");
            }
            catch (ErrorResponse e)
            {
                switch (e.ErrorType)
                {
                    case ErrorType.DatabaseConnection:
                        return RedirectToAction("Index", "Error", new { errorMessage = e.Message });
                    default:
                        TempData["ErrorMessage"] = e.Message;
                        return RedirectToAction("Detail", new { id = flightDetailViewModel.BookFlightId });
                }
            }
            catch (InvalidInputException e)
            {
                TempData["ErrorMessage"] = $"Error: {e.ErrorAndFixMessages.First().Error} Fix: {e.ErrorAndFixMessages.First().Fix}";
                return RedirectToAction("Detail", new { id = flightDetailViewModel.BookFlightId });
            }
        }

        [HttpPost]
        public ActionResult Index(FlightSearchViewModel flightViewModel)
        {
            try
            {
                FlightSearchViewModel newFlightViewModel = new(GetAllAstronomicalObjects(), GetAllSpaceport())
                {
                    Flights = flightContainer.SearchFlights(spaceportContainer, flightViewModel.LeaveDate, flightViewModel.OriginAOandSpaceportName, flightViewModel.DestinationAOandSpaceportName, flightViewModel.Travelers)
                    .Select(flight => new FlightModel(flight.Id, flight.DepartureTime, flight.Status, flight.FlightNumber, flight.OriginGate, flight.DestinationGate, flight.Spaceship, flight.FlightSchedule)).ToList(),
                };

                return View(newFlightViewModel);
            }
            catch (ErrorResponse e)
            {
                switch (e.ErrorType)
                {
                    case ErrorType.DatabaseConnection:
                        return RedirectToAction("Index", "Error", new { errorMessage = e.Message });
                    default:
                        FlightSearchViewModel flightSearchViewModel = new(GetAllAstronomicalObjects(), GetAllSpaceport());
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, e.Message);
                        return View(flightSearchViewModel);
                }
            }
            catch (InvalidInputException e)
            {
                FlightSearchViewModel flightSearchViewModel = new(GetAllAstronomicalObjects(), GetAllSpaceport());
                ModelState.Clear();
                e.ErrorAndFixMessages.ForEach(errorAndFixMessage =>
                {
                    ModelState.AddModelError(string.Empty, $"Error: {errorAndFixMessage.Error} Fix: {errorAndFixMessage.Fix}");
                });
                return View(flightSearchViewModel);
            }
        }

        private List<SpaceportModel> GetAllSpaceport()
        {
            return spaceportContainer.GetAll().Select(spaceport => 
            new SpaceportModel(
                spaceport.Id, 
                spaceport.Name, 
                new(
                    spaceport.AstronomicalObject.Id, 
                    spaceport.AstronomicalObject.Name, 
                    spaceport.AstronomicalObject.Radius, 
                    spaceport.AstronomicalObject.Azimuth, 
                    spaceport.AstronomicalObject.Inclination, 
                    spaceport.AstronomicalObject.OrbitalSpeed), 
                    null)
            ).ToList();
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
    }
}
