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
        [Route("{rentalId}")]
        public RentalModel GetRentalsByRentalId(long rentalId)
        {
            var rental = this.rentalService.GetRentalByRentalId(rentalId);

            return rental;
        }

        [HttpGet]
        public List<RentalModel> GetRentals()
        {
            var rentals = this.rentalService.GetAllRentals();

            return rentals;
        }

        [HttpGet]
        [Route("user/{userId}")]
        public List<RentalModel> GetRentalsByUserId(long userId)
        {
            var rentals = this.rentalService.GetAllRentalsByUserId(userId);

            return rentals;
        }

        [HttpGet]
        [Route("game/{gameId}")]
        public List<RentalModel> GetRentalsByGameId(long gameId)
        {
            var rentals = this.rentalService.GetAllRentalsByGameId(gameId);

            return rentals;
        }

        [HttpPost]
        public IActionResult CreateRental(RentalModel newRental)
        {
            return SaveRental(newRental);
        }

        [HttpPut]
        public IActionResult UpdateRental(RentalModel rental)
        {
            return SaveRental(rental);
        }

        private IActionResult SaveRental(RentalModel rental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (rental.Id > 0)
            {
                this.rentalService.UpdateRental(rental);
            }
            else
            {
                this.rentalService.AddRental(rental);
            }

            return Ok("Ok");
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
