﻿using Microsoft.AspNetCore.Mvc;

namespace what_u_gonna_eat.Controllers
{
    public class EaterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return NotFound();
        }
    }
}