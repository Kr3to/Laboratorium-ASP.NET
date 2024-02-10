using Laboratorium3_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laboratorium3_App.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [AllowAnonymous]
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
            var existingReservation = _reservationService.FindById(id);
            return View(existingReservation);
        }

        [HttpPost]
        public IActionResult Update(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _reservationService.Update(model);
                return RedirectToAction("index");
            }
            return View(model);
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
