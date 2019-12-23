using DAL;
using Microsoft.AspNetCore.Mvc;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly EfContext efContext;

        public WeatherForecastController(ICurrentDateService systemDateService, EfContext efContext)
        {
            this.systemDateService = systemDateService;
            this.efContext = efContext;
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
        public string GetCurrentUser()
        {
            var user = this.efContext.Users.Find(1);
            return user.FirstName;
        }
    }
}
