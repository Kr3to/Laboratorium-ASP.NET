using Laboratorium_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laboratorium_1.Controllers
{
    public enum Operators
    {
        ADD, SUB, MUL, DIV, POW
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Calculator(Operators op, double? a, double? b)
        {

            if (a == null || b == null || op == null)
            {
                return View("Error");
            }

            switch (op)
            {
                case Operators.ADD:
                    ViewBag.op = a + b;
                    break;
                case Operators.SUB:
                    ViewBag.op = a - b;
                    break;
                case Operators.MUL:
                    ViewBag.op = a * b;
                    break;
                case Operators.DIV:
                    ViewBag.op = a / b;
                    break;
                case Operators.POW:
                    ViewBag.op = Math.Pow((double)a, (double)b);
                    break;
                default: return View("Error");
            }


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}