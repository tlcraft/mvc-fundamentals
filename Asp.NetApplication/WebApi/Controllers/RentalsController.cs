using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    public class RentalsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateRental(RentalModel rental)
        {
            throw new NotImplementedException();
        }
    }
}
