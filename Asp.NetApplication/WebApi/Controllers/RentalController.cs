using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    public class RentalController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateRental(RentalModel rental)
        {
            throw new NotImplementedException();
        }
    }
}
