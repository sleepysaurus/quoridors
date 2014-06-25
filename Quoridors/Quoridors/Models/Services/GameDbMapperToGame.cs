using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Interfaces;

namespace Quoridors.Models.Services
{
    public class GameDbMapperToGame : IGameDbMapperToGame
    {
        private readonly IBoardStateUpdater _boardStateUpdater;
        private readonly IGameRepository _gameRepository;

        public GameDbMapperToGame(IBoardStateUpdater boardStateUpdater, IGameRepository gameRepository)
        {
            _boardStateUpdater = boardStateUpdater;
            _gameRepository = gameRepository;
        }

        public Game MappingGameFromDatabase(GameDb gameDb)
        {
            var game = new Game
            {
                Id = gameDb.Id,
                Turn = gameDb.Turn
            };

            _boardStateUpdater.UpdateBoardToSavedState(game);
            
            
            return game;
        }
    }
}