﻿using Shared.Models;
using System.Collections.Generic;

namespace Shared.Services
{
    public interface IGameService
    {
        List<GameModel> GetAllGames();
        GameModel GetGameById(long gameId);
        int AddGame(GameModel newGame);
        int UpdateGame(GameModel gameModel);
        int DeleteGame(long gameId);
    }
}
