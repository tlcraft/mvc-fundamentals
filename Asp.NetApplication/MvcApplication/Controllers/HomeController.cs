using DAL;
using Microsoft.AspNetCore.Mvc;
using MvcApplication.Models;
using Shared;
using System.Diagnostics;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrentDateService currentDateService;

        public HomeController(ICurrentDateService currentDateService)
        {
            this.currentDateService = currentDateService;
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
            using (var context = new EfContext())
            {

                var user = context.Users.Find(1);

                return user;
            }
        }
    }
}
