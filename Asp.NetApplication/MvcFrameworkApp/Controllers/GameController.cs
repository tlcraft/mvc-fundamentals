using DAL;
using MvcFrameworkApp.Models;
using Shared.Services;
using System.Linq;
using System.Web.Mvc;

namespace MvcFrameworkApp.Controllers
{
    public class GameController : Controller
    {
        private IUserService userService;
        private IGameService gameService;
        private EfContext efContext;

        public GameController(IUserService userService, IGameService gameService, EfContext efContext)
        {
            this.userService = userService;
            this.gameService = gameService;
            this.efContext = efContext;
        }

        public ActionResult GetGames()
        {
            var games = this.gameService.GetAllGames();
            return View("Games", games);
        }

        [Route("Game/Game/{gameId}")]
        public ActionResult GetGame(long gameId)
        {
            var selectedGame = this.gameService.GetGameById(gameId);
            return View("Game", selectedGame);
        }

        public ActionResult GetCustomers()
        {
            var customers = this.userService.GetAllUsers();
            return View("Customers", customers);
        }

        [Route("Game/Customer/{customerId}")]
        public ActionResult GetCustomer(int customerId)
        {
            var selectedCustomer = this.userService.GetUser(customerId);
            return View("Customer", selectedCustomer);
        }

        public ActionResult New()
        {
            var genres = efContext.GenreType.ToList();
            var newGameModel = new NewGameModel
            {
                GenreTypes = genres
            };
            return View(newGameModel);
        }
    }
}