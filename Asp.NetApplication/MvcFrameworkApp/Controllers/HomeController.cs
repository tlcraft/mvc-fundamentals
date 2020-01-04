using DAL;
using MvcFrameworkApp.Models;
using Shared.Services;
using System.Web.Mvc;

namespace MvcFrameworkApp.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService;
        private ICurrentDateService currentDateService;

        public HomeController(IUserService uSerService, ICurrentDateServiceFactory currentDateServiceFactory)
        {
            this.userService = userService;
            this.currentDateService = currentDateServiceFactory.GetCurrentDateService();
        }

        public ActionResult Index()
        {
            var model = new IndexModel();
            model.CurrentDate = currentDateService.CurrentDate;
            model.User = GetExampleUser();
            return View(model);
        }
        private User GetExampleUser()
        {
            var user = this.userService.GetUser(1);

            return user;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}