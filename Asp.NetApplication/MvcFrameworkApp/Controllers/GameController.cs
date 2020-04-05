using Shared.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcFrameworkApp.Controllers
{
    public class GameController : Controller
    {
        private Game[] Games = new Game[]
        {
            new Game
            {
                Id = 1,
                Name = "Animal Crossing",
                ReleaseDate = new DateTime(2020, 3, 20)
            },
            new Game
            {
                Id = 2,
                Name = "Doom Eternal",
                ReleaseDate = new DateTime(2020, 3, 20)
            }
        };

        private Customer[] Customers = new Customer[]
        {
                new Customer
                {
                    Id = 1,
                    Name = "Link"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Mario"
                }
        };

        public ActionResult GetGames()
        {
            return View("Games", Games);
        }

        [Route("Game/Game/{gameId}")]
        public ActionResult GetGame(long gameId)
        {
            var selectedGame = Games.FirstOrDefault(game => game.Id == gameId);
            return View("Game", selectedGame);
        }

        public ActionResult GetCustomers()
        {
            return View("Customers", Customers);
        }

        [Route("Game/Customer/{customerId}")]
        public ActionResult GetCustomer(long customerId)
        {
            var selectedCustomer = Customers.FirstOrDefault(customer => customer.Id == customerId);
            return View("Customer", selectedCustomer);
        }
    }
}