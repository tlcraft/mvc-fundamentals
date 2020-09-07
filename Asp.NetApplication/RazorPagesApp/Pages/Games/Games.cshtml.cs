extern alias SharedComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SharedComponents::Shared.Models;
using SharedComponents::Shared.Services;
using System.Collections.Generic;

namespace RazorPagesApp.Pages.Games
{
    public class GamesModel : PageModel
    {
        private readonly IGameService gameService;
        private readonly ILogger<GamesModel> logger;

        public List<GameModel> Games { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public GamesModel(IGameService gameService, ILogger<GamesModel> logger)
        {
            this.gameService = gameService;
            this.logger = logger;
        }

        public void OnGet()
        {
            this.Games = this.gameService.GetGamesByName(SearchTerm);
            this.logger.LogInformation("Executing GameModel.");
        }
    }
}
