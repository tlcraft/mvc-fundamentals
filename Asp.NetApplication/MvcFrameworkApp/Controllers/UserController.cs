using MvcFrameworkApp.Models;
using Shared.Services;
using System.Web.Mvc;

namespace MvcFrameworkApp.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        private IReferenceService referenceService;

        public UserController(IUserService userService, IReferenceService referenceService)
        {
            this.userService = userService;
            this.referenceService = referenceService;
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

        public ActionResult New()
        {
            var membershipTypes = referenceService.GetMembershipTypes();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Save(CustomerFormViewModel newCustomer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    UserModel = newCustomer.UserModel,
                    MembershipTypes = this.referenceService.GetMembershipTypes()
                };
                return View("CustomerForm", viewModel);
            }

            if (newCustomer.UserModel.Id == 0)
            {
                this.userService.AddUser(newCustomer.UserModel);
            }
            else
            {
                this.userService.UpdateUser(newCustomer.UserModel);
            }

            return RedirectToAction("GetCustomers", "User");
        }

        public ActionResult Edit(int customerId)
        {
            var selectedUser = this.userService.GetUser(customerId);
            if (selectedUser == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                UserModel = selectedUser,
                MembershipTypes = this.referenceService.GetMembershipTypes()
            };

            return View("CustomerForm", viewModel);
        }
    }
}