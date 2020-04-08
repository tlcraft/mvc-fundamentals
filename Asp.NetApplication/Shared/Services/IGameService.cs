using Shared.Models;
using System.Collections.Generic;

namespace Shared.Services
{
    public interface IGameService
    {
        List<Game> GetAllGames();
        Game GetGameById(long gameId);
    }
}
