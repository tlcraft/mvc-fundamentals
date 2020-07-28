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
            var selectedGame = this.efContext.Games.Include(game => game.GenreType).SingleOrDefault(game => game.Id == gameId);
            var gameModel = this.mapper.Map<Game, GameModel>(selectedGame);
            return gameModel;
        }

        public List<GameModel> GetGamesByName(string name = null)
        {
            var selectedGames = this.efContext.Games
                .Include(game => game.GenreType)
                .Where(game => string.IsNullOrWhiteSpace(name) || game.Name.ToLower().Contains(name.ToLower()))
                .ToList();

            var gameModels = this.mapper.Map<List<Game>, List<GameModel>>(selectedGames);
            return gameModels;
        }

        public long AddGame(GameModel newGame)
        {
            var game = this.mapper.Map<GameModel, Game>(newGame);
            this.efContext.Games.Add(game);

            this.efContext.SaveChanges();
            return game.Id;
        }

        public int UpdateGame(GameModel selectedGame)
        {
            var dbGame = this.efContext.Games.Include(game => game.GenreType).SingleOrDefault(game => game.Id == selectedGame.Id);
            dbGame = this.mapper.Map<GameModel, Game>(selectedGame, dbGame);

            var totalStateEntriesWritten = this.efContext.SaveChanges();
            return totalStateEntriesWritten;
        }

        public int DeleteGame(long gameId)
        {
            var dbGame = this.efContext.Games.SingleOrDefault(game => game.Id == gameId);

            if(dbGame == null)
            {
                return 0;
            }

            this.efContext.Games.Remove(dbGame);

            var totalStateEntriesWritten = this.efContext.SaveChanges();
            return totalStateEntriesWritten;
        }
    }
}
