using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Models;
using Shared.Services;

namespace RazorPagesApp.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly IGameService GameService;

        public GameModel Game { get; set; }
        [TempData]
        public string Message { get; set; }

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
