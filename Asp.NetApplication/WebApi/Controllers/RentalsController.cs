using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Services;
using System.Collections.Generic;

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
        public List<RentalModel> GetRentalsByUserId(long userId)
        {
            var rentals = this.rentalService.GetAllRentalsByUserId(userId);

            return rentals;
        }

        [HttpDelete]
        [Route("{rentalId}")]
        public IActionResult DeleteRental(long rentalId)
        {
            if (rentalId <= 0)
            {
                return BadRequest();
            }

            var recordsUpdated = this.rentalService.DeleteRental(rentalId);

            if (recordsUpdated <= 0)
            {
                return BadRequest($"The rentalId: {rentalId} doesn't exist.");
            }

            return Ok("Ok");
        }
    }
}
