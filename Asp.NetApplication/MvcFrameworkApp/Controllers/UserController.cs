using AutoMapper;
using MvcFrameworkApp.Models;
using Shared.Models;
using Shared.Services;
using System.Web.Mvc;

namespace MvcFrameworkApp.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        private IReferenceService referenceService;
        private IMapper mapper;

        public UserController(IUserService userService, IReferenceService referenceService, IMapper mapper)
        {
            this.userService = userService;
            this.referenceService = referenceService;
            this.mapper = mapper;
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
                    Id = newCustomer.Id ?? 0,
                    FirstName = newCustomer.FirstName,
                    LastName = newCustomer.LastName,
                    MembershipTypeId = newCustomer.MembershipTypeId,
                    Birthdate = newCustomer.Birthdate,
                    MembershipTypes = this.referenceService.GetMembershipTypes()
                };
                return View("CustomerForm", viewModel);
            }

            var userModel = this.mapper.Map<CustomerFormViewModel, UserModel>(newCustomer);

            if (userModel.Id == 0)
            {
                this.userService.AddUser(userModel);
            }
            else
            {
                this.userService.UpdateUser(userModel);
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
                Id = selectedUser.Id,
                FirstName = selectedUser.FirstName,
                LastName = selectedUser.LastName,
                MembershipTypeId = selectedUser.MembershipType.Id,
                Birthdate = selectedUser.Birthdate,
                MembershipTypes = this.referenceService.GetMembershipTypes()
            };

            return View("CustomerForm", viewModel);
        }
    }
}