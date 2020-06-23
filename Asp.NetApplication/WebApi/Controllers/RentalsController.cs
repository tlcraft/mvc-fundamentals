using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Services;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalsController : ControllerBase
    {
        private IRentalService rentalService;

        public RentalsController(IRentalService rentalService)
        {
            this.rentalService = rentalService;
        }

        [HttpGet]
        [Route("{userId}")]
        public RentalModel GetRentals(long userId)
        {
            var rentals = this.rentalService.GetAllRentalsByUserId(userId);

            return rentals;
        }

        [HttpPost]
        public IActionResult CreateRental(RentalModel rental)
        {
            throw new NotImplementedException();
        }
    }
}
