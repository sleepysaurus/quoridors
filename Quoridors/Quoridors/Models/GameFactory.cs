using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models
{
    public class GameFactory
    {
        private readonly IBoardStateUpdater _boardStateUpdater;
        private readonly IGameRepository _gameRepository;
        private readonly GameDbMapperToGame _dbMapperToGame = new GameDbMapperToGame();

        public GameFactory(IBoardStateUpdater boardStateUpdater, IGameRepository gameRepository)
        {
            _boardStateUpdater = boardStateUpdater;
            _gameRepository = gameRepository;
        }

        public Game New()
        {
            var gameDb = _gameRepository.CreateGame();
            var game = new Game
            {
                Id = gameDb,
                Turn = 0
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