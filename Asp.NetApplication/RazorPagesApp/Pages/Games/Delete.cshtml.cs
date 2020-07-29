using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Services;
using Shared.Models;

namespace RazorPagesApp.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly IGameService gameService;
        public GameModel Game { get; set; } 

        public DeleteModel(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public IActionResult OnGet(long gameId)
        {
            Game = this.gameService.GetGameById(gameId);
            if(Game == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(long gameId)
        {
            var recordsDeleted = this.gameService.DeleteGame(gameId);
            if(recordsDeleted == 0)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"Deleted game.";
            return RedirectToPage("./Games");

        }
    }
}
