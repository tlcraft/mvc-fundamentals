using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
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

        public List<GameModel> GetAllGames()
        {
            var games = this.efContext.Games.Include(game => game.GenreType).ToList();
            var gameModels = this.mapper.Map<List<Game>, List<GameModel>>(games);
            return gameModels;
        }

        public GameModel GetGameById(long gameId)
        {
            var selectedGame = efContext.Games.Include(game => game.GenreType).SingleOrDefault(game => game.Id == gameId);
            var gameModel = this.mapper.Map<Game, GameModel>(selectedGame);
            return gameModel;
        }

        public int AddGame(GameModel newGame)
        {
            var game = this.mapper.Map<GameModel, Game>(newGame);
            this.efContext.Games.Add(game);

            var totalStateEntriesWritten = this.efContext.SaveChanges();
            return totalStateEntriesWritten;
        }

        public int UpdateGame(GameModel selectedGame)
        {
            var dbGame = efContext.Games.Include(game => game.GenreType).SingleOrDefault(game => game.Id == selectedGame.Id);
            dbGame = this.mapper.Map<GameModel, Game>(selectedGame, dbGame);

            var totalStateEntriesWritten = this.efContext.SaveChanges();
            return totalStateEntriesWritten;
        }

        public int DeleteGame(long gameId)
        {
            var dbGame = efContext.Games.SingleOrDefault(game => game.Id == gameId);

            if(dbGame == null)
            {
                return 0;
            }

            efContext.Games.Remove(dbGame);

            var totalStateEntriesWritten = this.efContext.SaveChanges();
            return totalStateEntriesWritten;
        }
    }
}
