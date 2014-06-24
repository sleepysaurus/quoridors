using System.Linq;
using Quoridors.Models.Database;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Services
{
    public interface IBoardStateUpdater // BA move out into its own file
    {
        Game AddWall(WallDb wallposition, Game game);
        void UpdateBoardToSavedState(Game game);
        Game MovePlayer(PositionDb position, Game game);
    }

    public class BoardStateUpdater : IBoardStateUpdater
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IWallRepository _wallRepository;

        public BoardStateUpdater(IPositionRepository positionRepository, IWallRepository wallRepository)
        {
            _positionRepository = positionRepository;
            _wallRepository = wallRepository;
        }

        public Game AddWall(WallDb wallposition, Game game)
        {
            if (wallposition.Direction == 0) //then wall is facing down.
            {
                game.Board[wallposition.XPos * 2 + 1][wallposition.YPos * 2] = BoardCellStatus.Wall;
                game.Board[wallposition.XPos * 2 + 3][wallposition.YPos * 2] = BoardCellStatus.Wall;
            }

            if (wallposition.Direction == 1)   //then wall is going right.
            {
                game.Board[wallposition.XPos * 2][wallposition.YPos * 2 + 1] = BoardCellStatus.Wall;
                game.Board[wallposition.XPos * 2][wallposition.YPos * 2 + 3] = BoardCellStatus.Wall;
            }

            return game;
        }

        public Game MovePlayer(PositionDb position, Game game)
        {
            var originalPosition = new PlayerRepository().GetPosition(position.PlayerId);// BA move this to the constructor
            game.Board[originalPosition.Horizontal][originalPosition.Vertical] = BoardCellStatus.Empty; // BA ditto
            game.Board[position.XPos][position.YPos] = BoardCellStatus.Player1; // If loop to check which player is being moved
            return game;
        }

        public void UpdateBoardToSavedState(Game game)
        {
            var playerPositions = _positionRepository.GetByGame(game.Id).ToList();

            var listOfWalls = _wallRepository.GetByGameId(game.Id).ToList();


            foreach (var player in playerPositions)
            {
                game.Board[player.XPos * 2 + 1][player.YPos * 2 + 1] = BoardCellStatus.Player1; // Another if loop, to see which player to be moved.
            }

            foreach (var wall in listOfWalls)
            {
                if (wall.Direction == 0) //then wall is facing down.
                {
                    game.Board[wall.XPos * 2 + 1][wall.YPos * 2] = BoardCellStatus.Wall; // BA const or enum
                    game.Board[wall.XPos * 2 + 3][wall.YPos * 2] = BoardCellStatus.Wall;
                }
                if (wall.Direction != 1) continue;
                game.Board[wall.XPos * 2][wall.YPos * 2 + 1] = BoardCellStatus.Wall;
                game.Board[wall.XPos * 2][wall.YPos * 2 + 3] = BoardCellStatus.Wall;
            }
        } 
    }
}