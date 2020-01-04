using MvcFrameworkApp.Models;
using Shared.Services;
using System.Web.Mvc;

namespace MvcFrameworkApp.Controllers
{
    public class HomeController : Controller
    {
        private ICurrentDateService currentDateService;

        public HomeController(ICurrentDateServiceFactory currentDateServiceFactory)
        {
            this.currentDateService = currentDateServiceFactory.GetCurrentDateService();
        }

        public ActionResult Index()
        {
            var model = new IndexModel();
            model.CurrentDate = currentDateService.CurrentDate;
            return View(model);
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