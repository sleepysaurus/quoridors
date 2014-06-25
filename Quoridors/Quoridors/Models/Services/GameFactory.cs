using System.Collections.Generic;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.Interfaces;

namespace Quoridors.Models.Services
{
    // BA clean this class up
    public class GameFactory : IGameFactory
    {
        private readonly IBoardStateUpdater _boardStateUpdater;
        private readonly IGameRepository _gameRepository;
        private readonly IGameDbMapperToGame _dbMapperToGame;
        private readonly IBoardFactory _boardFactory;

        public GameFactory(IBoardStateUpdater boardStateUpdater, IGameRepository gameRepository, IGameDbMapperToGame dbMapperToGame, IBoardFactory boardFactory)
        {
            _boardStateUpdater = boardStateUpdater;
            _gameRepository = gameRepository;
            _dbMapperToGame = dbMapperToGame;
            _boardFactory = boardFactory;
        }

        public Game New() // BA pass in the player names ;)
        {
            var gameId = _gameRepository.CreateGame().Id;

            var game = new Game(new Player(1, "John", new Position(4, 8)), new Player(2, "Samantha", new Position(4, 0)), _boardFactory.CreateBoard(), gameId); // TODO call constructor which takes 2 players and the board that the BoardFactory produces
            
            //save to new game db
            return game;
        }

        public Game Load(int gameId)
        {
            var gameDb = _gameRepository.GetById(gameId);
            var game = _dbMapperToGame.MappingGameFromDatabase(gameDb);
            return game;
        }
    }
}