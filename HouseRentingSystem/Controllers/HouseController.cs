﻿using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    public class HouseController : Controller
    {
        public IActionResult All()
        {
            return View();
        }

        public IActionResult Mine()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
