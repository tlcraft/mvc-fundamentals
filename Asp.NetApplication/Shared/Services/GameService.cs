using AutoMapper;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Services
{
    public class GameService : IGameService
    {
        private EfContext efContext;
        private IMapper mapper;

        public GameService(EfContext efContext, IMapper mapper)
        {
            this.efContext = efContext;
            this.mapper = mapper;
        }

        public List<Models.Game> GetAllGames()
        {
            var games = this.efContext.Games.ToList();
            var gameModels = this.mapper.Map<List<Game>, List<Models.Game>>(games);
            return gameModels;
        }

        public Models.Game GetGameById(long gameId)
        {
            var selectedGame = efContext.Games.FirstOrDefault(game => game.Id == gameId);
            var gameModel = this.mapper.Map<Game, Models.Game>(selectedGame);
            return gameModel;
        }
    }
}
