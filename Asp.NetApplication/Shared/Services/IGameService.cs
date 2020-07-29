using Shared.Models;
using System.Collections.Generic;

namespace Shared.Services
{
    public interface IGameService
    {
        List<GameModel> GetAllGames();
        GameModel GetGameById(long gameId);
        List<GameModel> GetGamesByName(string name);
        long AddGame(GameModel newGame);
        int UpdateGame(GameModel gameModel);
        int DeleteGame(long gameId);
        int GetTotalNumberOfGames();
    }
}
