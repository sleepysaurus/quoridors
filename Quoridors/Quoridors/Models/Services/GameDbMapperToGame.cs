using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Interfaces;
using Quoridors.Models.Services;

namespace Quoridors.Models
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
            Game game = new Game
            {
                Id = gameDb.Id
            };

            _boardStateUpdater.UpdateBoardToSavedState(game);
            
            return game;
        }
    }
}