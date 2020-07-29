using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Models;
using Shared.Services;
using System.Collections.Generic;

namespace RazorPagesApp.Pages.Games
{
    public class GamesModel : PageModel
    {
        private IGameService gameService;
        public List<GameModel> Games { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public GamesModel(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public void OnGet()
        {
            this.Games = this.gameService.GetGamesByName(SearchTerm);
        }
    }
}
