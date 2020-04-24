using Shared.Services;
using System.Web.Mvc;

namespace MvcFrameworkApp.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult GetCustomers()
        {
            var customers = this.userService.GetAllUsers();
            return View("Customers", customers);
        }

        [Route("User/Customer/{customerId}")]
        public ActionResult GetCustomer(int customerId)
        {
            var selectedCustomer = this.userService.GetUser(customerId);
            return View("Customer", selectedCustomer);
        }
    }
}