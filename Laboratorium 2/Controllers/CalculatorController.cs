using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_2.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Result([FromForm]Models.Calculator model)
        {
            if (!model.IsValid()) return BadRequest();

            return View(model);
        }
    }
}
