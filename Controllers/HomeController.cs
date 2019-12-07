using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_fundamentals.Models;
using System.Diagnostics;

namespace mvc_fundamentals.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ISystemTime systemTime;

        public HomeController(ILogger<HomeController> logger, ISystemTime systemTime)
        {
            this.logger = logger;
            this.systemTime = systemTime;
        }

        public IActionResult Index()
        {
            var model = new IndexModel();
            model.SystemTime = systemTime.CurrentDate;
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
