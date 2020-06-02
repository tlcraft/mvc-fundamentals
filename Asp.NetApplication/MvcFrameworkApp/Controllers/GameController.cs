using AutoMapper;
using MvcFrameworkApp.Models;
using Shared.Models;
using Shared.Services;
using System.Web.Mvc;

namespace MvcFrameworkApp.Controllers
{
    public class GameController : Controller
    {
        private IGameService gameService;
        private IReferenceService referenceService;
        private IMapper mapper;

        public GameController(IGameService gameService, IReferenceService referenceService, IMapper mapper)
        {
            this.gameService = gameService;
            this.referenceService = referenceService;
            this.mapper = mapper;
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
        [ValidateAntiForgeryToken()]
        public ActionResult Save(GameFormViewModel newGame)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new GameFormViewModel
                {
                    GenreTypeId = newGame.GenreTypeId,
                    Name = newGame.Name,
                    ReleaseDate = newGame.ReleaseDate,
                    Id = newGame.Id ?? 0,
                    GenreTypes = this.referenceService.GetGenreTypes()
                };

                return View("GameForm", viewModel);
            }

            var gameModel = this.mapper.Map<GameFormViewModel, GameModel>(newGame);

            if (gameModel.Id == 0)
            {
                this.gameService.AddGame(gameModel);
            }
            else
            {
                this.gameService.UpdateGame(gameModel);
            }

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
                Id = selectedGame.Id,
                Name = selectedGame.Name,
                ReleaseDate = selectedGame.ReleaseDate,
                GenreTypeId = selectedGame.GenreType.Id,
                GenreTypes = this.referenceService.GetGenreTypes()
            };

            return View("GameForm", viewModel);
        }
    }
}