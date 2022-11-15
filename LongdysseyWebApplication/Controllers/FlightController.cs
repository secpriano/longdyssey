using BLL.Container;
using BLL.Entity;
using DAL;
using LongdysseyWebApplication.Models;
using LongdysseyWebApplication.Models.FlightModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Test.STUB;

namespace LongdysseyWebApplication.Controllers
{
    public class FlightController : Controller
    {
        private readonly FlightContainer fc = new(new FlightDAL());
        private readonly PointOfInterestContainer pc = new(new PointOfInterestDAL());
        private readonly SpaceportContainer sc = new(new SpaceportSTUB());

        // GET: FlightController
        [HttpGet]
        public ActionResult Index()
        {
            FlightViewModel flightViewModel = new(pc.GetAll(), sc.GetAll());
            return View(flightViewModel);
        }

        // GET: FlightController/Detail/5
        [HttpGet]
        public ActionResult Detail(int id)
        {
            Flight flight = fc.GetByID(id);
            flight.C = new BoardingpassDAL();
            List<Boardingpass> boardingpasses = flight.GetBookingByFlightId();
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
            FlightDetailViewModel flightDetailViewModel = new(flight, availableSeats);
            return View(flightDetailViewModel);
        }

        [HttpPost]
        public ActionResult BookFlight(FlightDetailViewModel flightDetailViewModel)
        {
            Flight flight = fc.GetByID(flightDetailViewModel.BookFlightId);
            flight.C = new BoardingpassDAL();
            flight.BookFlight(flightDetailViewModel.SelectedSeat, new(1, "an", "on", "anon@email.com", 1481, true));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index(FlightViewModel flightViewModel)
        {
            FlightViewModel newFlightViewModel = new(pc.GetAll(), sc.GetAll())
            {
                Flights = fc.SearchFlights(flightViewModel.LeaveDate, Convert.ToInt64(flightViewModel.OriginPOI), Convert.ToInt64(flightViewModel.DestinationPOI), flightViewModel.Travelers)
            };
            return View(newFlightViewModel);
        }
    }
}
