﻿using Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Result(Birth model)
        {
            if (!model.IsValid()) return BadRequest();

            return View(model);
        }
    }
}