﻿using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcApplication.Models;
using System.Diagnostics;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ICurrentDateService currentDateService;

        public HomeController(ILogger<HomeController> logger, ICurrentDateService currentDateService)
        {
            this.logger = logger;
            this.currentDateService = currentDateService;
        }

        public IActionResult Index()
        {
            var model = new IndexModel();
            model.CurrentDate = currentDateService.CurrentDate;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
