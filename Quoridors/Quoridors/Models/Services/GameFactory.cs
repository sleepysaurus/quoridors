using System.Collections.Generic;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.Interfaces;

namespace Quoridors.Models.Services
{
    public class GameFactory : IGameFactory
    {
        private readonly IBoardStateUpdater _boardStateUpdater;
        private readonly IGameRepository _gameRepository;
        private readonly IGameDbMapperToGame _dbMapperToGame;

        public GameFactory(IBoardStateUpdater boardStateUpdater, IGameRepository gameRepository, IGameDbMapperToGame dbMapperToGame)
        {
            _boardStateUpdater = boardStateUpdater;
            _gameRepository = gameRepository;
            _dbMapperToGame = dbMapperToGame;
        }

        public Game New() // BA pass in the player names ;)
        {
            var gameId = _gameRepository.CreateGame();
            var player1 = new Player(1, "John");
            var player2 = new Player(2, "Samantha");
            var players = new List<Player>
            {
                player1,
                player2
            };
            var game = new Game
            {
                Id = gameId,
                Turn = 0,
                Players = players
            };
            
            //save to new game db
            return game;
        }

        public Game Load(int gameId)
        {
            var gameDb = _gameRepository.GetById(gameId);
            var game = _dbMapperToGame.MappingGameFromDatabase(gameDb);
            _boardStateUpdater.UpdateBoardToSavedState(game);
            return game;
        }

    }
}