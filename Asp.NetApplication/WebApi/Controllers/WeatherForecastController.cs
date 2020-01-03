using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shared.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ICurrentDateService systemDateService;
        private readonly IUserService userService;

        public WeatherForecastController(ICurrentDateServiceFactory currentDateServiceFactory, IUserService userService)
        {
            this.systemDateService = currentDateServiceFactory.GetCurrentDateService();
            this.userService = userService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("currentDate")]
        public string GetCurrentDate()
        {
            return systemDateService.CurrentDate;
        }

        [HttpGet]
        [Route("user")]
        public string GetCurrentUser([FromQuery] int userId)
        {
            var user = this.userService.GetUser(userId);
            return user.FirstName;
        }
    }
}
