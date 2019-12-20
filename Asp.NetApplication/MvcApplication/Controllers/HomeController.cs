using DAL;
using Microsoft.AspNetCore.Mvc;
using MvcApplication.Models;
using Shared;
using System.Diagnostics;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly EfContext efContext;
        private readonly ICurrentDateService currentDateService;

        public HomeController(ICurrentDateService currentDateService, EfContext context)
        {
            this.currentDateService = currentDateService;
            this.efContext = context;
        }

        public IActionResult Index()
        {
            var model = new IndexModel();
            model.CurrentDate = currentDateService.CurrentDate;
            model.User = GetExampleUser();

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

        private User GetExampleUser()
        {
            var user = this.efContext.Users.Find(1);

            return user;
        }
    }
}
