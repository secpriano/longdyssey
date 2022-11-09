using BLL.Container;
using DAL;
using LongdysseyWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        // GET: FlightController/Details/5
        [HttpGet]
        public ActionResult Detail(int id)
        {
            return View();
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
