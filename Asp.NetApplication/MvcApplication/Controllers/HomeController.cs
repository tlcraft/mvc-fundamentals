using System.Diagnostics;
using DAL;
using Microsoft.AspNetCore.Mvc;
using MvcApplication.Models;
using Shared.Services;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly ICurrentDateService currentDateService;

        public HomeController(INativeCurrentDateFactory nativeCurrentDateFactory, IUserService userService)
        {
            this.currentDateService = nativeCurrentDateFactory.GetNativeCurrentDateService();
            this.userService = userService;
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
            var user = this.userService.GetUser(1);

            return user;
        }
    }
}
