using Laboratorium_3_4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laboratorium_3_4.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public IActionResult Index()
        {
            return View(_reservationService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _reservationService.Add(reservation);
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_reservationService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _reservationService.Update(model);
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Details(int id)
        {
            return View(_reservationService.FindById(id));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_reservationService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Reservation model)
        {
            _reservationService.DeleteById(model.Id);
            return RedirectToAction("index");
        }
    }
}
