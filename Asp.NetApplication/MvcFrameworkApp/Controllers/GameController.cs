using MvcFrameworkApp.Models;
using Shared.Services;
using System.Web.Mvc;

namespace MvcFrameworkApp.Controllers
{
    public class GameController : Controller
    {
        private IUserService userService;
        private IGameService gameService;
        private IReferenceService referenceService;

        public GameController(IUserService userService, IGameService gameService, IReferenceService referenceService)
        {
            this.userService = userService;
            this.gameService = gameService;
            this.referenceService = referenceService;
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
            var genres = referenceService.GetGenreTypes();
            var newGameModel = new GameFormViewModel
            {
                GenreTypes = genres
            };
            return View("GameForm", newGameModel);
        }

        [HttpPost]
        public ActionResult Create(GameFormViewModel newGame)
        {
            this.gameService.AddGame(newGame.GameModel);
            return RedirectToAction("GetGames", "Game");
        }

        public ActionResult Edit(int gameId)
        {
            var selectedGame = this.gameService.GetGameById(gameId);
            if(selectedGame == null)
            {
                return HttpNotFound();
            }

            var viewModel = new GameFormViewModel
            {
                GameModel = selectedGame,
                GenreTypes = this.referenceService.GetGenreTypes()
            };

            return View("GameForm", viewModel);
        }
    }
}