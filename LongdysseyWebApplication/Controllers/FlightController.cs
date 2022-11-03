using BLL.Container;
using DAL;
using LongdysseyWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LongdysseyWebApplication.Controllers
{
    public class FlightController : Controller
    {
        private readonly FlightContainer fc = new(new FlightDAL());
        private readonly PointOfInterestContainer pc = new(new PointOfInterestDAL());

        // GET: FlightController
        public ActionResult Index()
        {
            FlightViewModel flightViewModel = new(fc.GetAll(), pc.GetAll());
            return View(flightViewModel);
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
