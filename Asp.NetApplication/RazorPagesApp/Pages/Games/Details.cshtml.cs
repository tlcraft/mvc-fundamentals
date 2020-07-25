using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Models;
using Shared.Services;

namespace RazorPagesApp.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private IGameService GameService { get; set; }

        public GameModel Game { get; set; }

        public DetailsModel(IGameService gameService)
        {
            this.GameService = gameService;
        }

        public IActionResult OnGet(long gameId)
        {
            Game = this.GameService.GetGameById(gameId);

            if(Game == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
