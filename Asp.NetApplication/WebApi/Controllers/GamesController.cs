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
        public IEnumerable<GameModel> GetGames()
        {
            var games = this.gameService.GetAllGames();

            return games;
        }

        [HttpGet]
        [Route("{gameId}")]
        public IActionResult GetGame(long gameId)
        {
            var game = this.gameService.GetGameById(gameId);

            if(game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public IActionResult CreateGame(GameModel newGame)
        {
            return SaveGame(newGame);
        }

        [HttpPut]
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

        [HttpDelete]
        [Route("{gameId}")]
        public IActionResult DeleteGame(long gameId)
        {
            if(gameId <= 0)
            {
                return BadRequest();
            }

            var recordsUpdated = this.gameService.DeleteGame(gameId);

            if(recordsUpdated <= 0)
            {
                return BadRequest($"The gameId: {gameId} doesn't exist.");
            }

            return Ok();
        }
    }
}
