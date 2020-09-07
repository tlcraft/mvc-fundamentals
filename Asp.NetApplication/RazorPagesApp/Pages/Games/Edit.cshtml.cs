extern alias SharedComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SharedComponents::Shared.Models;
using SharedComponents::Shared.Services;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesApp.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly IGameService gameService;
        private readonly IReferenceService referenceService;

        [BindProperty]
        public GameModel Game { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        public EditModel(IGameService gameService, IReferenceService referenceService)
        {
            this.gameService = gameService;
            this.referenceService = referenceService;
        }

        public IActionResult OnGet(long? gameId)
        {
            if (gameId.HasValue)
            {
                Game = this.gameService.GetGameById(gameId.Value);
            }
            else
            {
                Game = new GameModel();
            }

            if (Game == null)
            {
                return RedirectToPage("./NotFound");
            }

            InitializeGenreTypes();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                InitializeGenreTypes();
                return Page();
            }

            var genreId = this.referenceService.GetGenreTypes().Single(genre => genre.Name == Game.GenreType.Name).Id;
            Game.GenreType.Id = genreId;

            long gameId;
            if (Game.Id > 0)
            {
                gameService.UpdateGame(Game);
                gameId = Game.Id;
            }
            else
            {
                gameId = gameService.AddGame(Game);
            }
            TempData["Message"] = "Game saved!";
            return RedirectToPage("./Details", new { gameId = gameId });
        }

        private void InitializeGenreTypes()
        {
            Genres = this.referenceService.GetGenreTypes().Select(genre => new SelectListItem()
            {
                Selected = Game.GenreType != null ? Game.GenreType.Id == genre.Id : false,
                Text = genre.Name,
                Value = genre.Name
            });
        }
    }
}
