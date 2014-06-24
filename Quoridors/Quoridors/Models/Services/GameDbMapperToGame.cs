using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Interfaces;

namespace Quoridors.Models.Services
{
    public class GameDbMapperToGame : IGameDbMapperToGame
    {
        private readonly IBoardStateUpdater _boardStateUpdater;

        public GameDbMapperToGame(IBoardStateUpdater boardStateUpdater)
        {
            _boardStateUpdater = boardStateUpdater;
        }

        public Game MappingGameFromDatabase(GameDb gameDb)
        {
            var game = new Game
            {
                Id = gameDb.Id
            };

            _boardStateUpdater.UpdateBoardToSavedState(game);
            
            return game;
        }
    }
}