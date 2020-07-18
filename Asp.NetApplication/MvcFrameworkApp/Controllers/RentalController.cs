using Shared.Services;
using System.Web.Mvc;

namespace MvcFrameworkApp.Controllers
{
    public class RentalController : Controller
    {
        private IRentalService rentalService;

        public RentalController(IRentalService rentalService)
        {
            this.rentalService = rentalService;
        }

        public ActionResult GetRentals()
        {
            var rentals = this.rentalService.GetAllRentals();
            return View("Rentals", rentals);
        }
    }
}