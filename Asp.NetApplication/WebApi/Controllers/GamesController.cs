using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Services;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private IGameService gameService;

        public GamesController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        [Route("games")]
        public IEnumerable<GameModel> GetGames()
        {
            var games = this.gameService.GetAllGames();

            return games;
        }

        [HttpGet]
        [Route("game/{id}")]
        public IActionResult GetGame(int id)
        {
            var game = this.gameService.GetGameById(id);

            if(game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        [Route("games")]
        public IActionResult CreateGame(GameModel newGame)
        {
            return SaveGame(newGame);
        }

        [HttpPut]
        [Route("games")]
        public IActionResult UpdateGame(GameModel game)
        {
            return SaveGame(game);
        }

        private IActionResult SaveGame(GameModel game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(game.Id > 0)
            {
                this.gameService.UpdateGame(game);
            }
            else
            {
                this.gameService.AddGame(game);
            }

            return Ok();
        }
    }
}
