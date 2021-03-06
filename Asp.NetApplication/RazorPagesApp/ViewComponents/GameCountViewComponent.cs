﻿extern alias SharedComponents;
using Microsoft.AspNetCore.Mvc;
using SharedComponents::Shared.Services;

namespace RazorPagesApp.ViewComponents
{
    public class GameCountViewComponent : ViewComponent
    {
        private readonly IGameService gameService;

        public GameCountViewComponent(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public IViewComponentResult Invoke()
        {
            var count = this.gameService.GetTotalNumberOfGames();
            return View(count);
        }
    }
}
