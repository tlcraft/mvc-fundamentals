using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Models;
using Shared.Services;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesApp.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly IGameService gameService;
        private readonly IReferenceService referenceService;

        public GameModel Game { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        public EditModel(IGameService gameService, IReferenceService referenceService)
        {
            this.gameService = gameService;
            this.referenceService = referenceService;
        }

        public IActionResult OnGet(long gameId)
        {
            Game = this.gameService.GetGameById(gameId);
            Genres = this.referenceService.GetGenreTypes().Select(genre => new SelectListItem()
            {
                Selected = Game.GenreType.Id == genre.Id,
                Text = genre.Name, 
                Value = genre.Name 
            });

            if (Game == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
