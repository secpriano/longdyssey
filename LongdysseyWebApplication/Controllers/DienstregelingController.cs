using Algorithm;
using BLL.Container;
using DAL;
using IL.DTO;
using LongdysseyWebApplication.Models.Dienstregeling;
using LongdysseyWebApplication.Models.FlightModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LongdysseyWebApplication.Controllers
{
    public class DienstregelingController : Controller
    {
        private readonly AstronomicalObjectContainer astronomicalObjectContainer = new(new AstronomicalObjectDAL());

        // GET: DienstregelingController
        public ActionResult Index()
        {
            DienstregelingViewModel dienstregelingViewModel = new(GetAllAO());

            return View(dienstregelingViewModel);
        }

        private List<AstronomicalObjectModel> GetAllAO() => astronomicalObjectContainer.GetAll().Select(AO => new AstronomicalObjectModel(AO.Id, AO.Name, AO.Radius, AO.Azimuth, AO.Inclination, AO.OrbitalSpeed)).ToList();

        public ActionResult GenerateFlightSchedule()
        {
            List<AstronomicalObjectDTO> DTOs = astronomicalObjectContainer.GetAll().Select(AO => AO.GetDTO())
                .Select(DTO => new AstronomicalObjectDTO(DTO.Id, DTO.Name, DTO.Radius, DTO.Azimuth, DTO.Inclination, DTO.OrbitalSpeed)).ToList();
            
            FlightScheduler fs = new(new(1, "Longdyssey A380", 380, 0.2M, 1), DTOs, DateTime.Now);
            return View();
        }

        // GET: DienstregelingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DienstregelingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DienstregelingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DienstregelingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DienstregelingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DienstregelingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DienstregelingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
