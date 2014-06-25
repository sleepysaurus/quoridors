using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Interfaces;

namespace Quoridors.Models.Services
{
    public class GameDbMapperToGame : IGameDbMapperToGame
    {
        private readonly IBoardStateUpdater _boardStateUpdater;
        private readonly IBoardFactory _boardFactory;

        public GameDbMapperToGame(IBoardStateUpdater boardStateUpdater, IBoardFactory boardFactory)
        {
            _boardStateUpdater = boardStateUpdater;
            _boardFactory = boardFactory;
        }

        public Game MappingGameFromDatabase(GameDb gameDb)
        {
            var game = new Game(gameDb.Id, gameDb.Turn, _boardFactory.CreateBoard());

            _boardStateUpdater.UpdateBoardToSavedState(game);
            
            return game;
        }
    }
}