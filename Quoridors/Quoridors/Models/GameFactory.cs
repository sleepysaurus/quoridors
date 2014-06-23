using Quoridors.Models.Database;

namespace Quoridors.Models
{
    public class GameFactory
    {
        private readonly IBoardStateUpdater _boardStateUpdater;

        public GameFactory(IBoardStateUpdater boardStateUpdater)
        {
            _boardStateUpdater = boardStateUpdater;
        }

        public Game New()
        {
            return new Game();
        }

        public Game Load(int gameId)
        {
             var game = new GameRepository().GetById(gameId); // TODO BA move this to an IGameRepository on the constructor 
            // TODO map from GameDb to Game
            _boardStateUpdater.UpdateBoardToSavedState(game);
            return game;
        }

    }
}