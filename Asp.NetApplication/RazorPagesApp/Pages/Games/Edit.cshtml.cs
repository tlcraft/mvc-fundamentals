using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Models;
using Shared.Services;

namespace RazorPagesApp.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly IGameService gameService;
        public GameModel Game { get; set; }

        public EditModel(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public IActionResult OnGet(long gameId)
        {
            Game = this.gameService.GetGameById(gameId);

            if (Game == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
