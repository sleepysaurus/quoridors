using System.Linq;
using Quoridors.Models.Database;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Interfaces;

namespace Quoridors.Models.Services
{
    public class BoardStateUpdater : IBoardStateUpdater
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IWallRepository _wallRepository;
        private readonly IPlayerRepository _playerRepository;

        public BoardStateUpdater(IPositionRepository positionRepository, IWallRepository wallRepository, IPlayerRepository playerRepository)
        {
            _positionRepository = positionRepository;
            _wallRepository = wallRepository;
            _playerRepository = playerRepository;
        }

        // M D comments
        // We need to be given the position so that the wall is on its left or top
        // If we are given (1,1) down, wall goes to (2,1) and (4,1)
        // (3,4) down, wall goes to (6,7)

        // (1,1) right, goes to (1,2) and (1,4)
        // (3,4) right, goes to (5,8) and (5, 10)
        public Game AddWall(WallDb wallposition, Game game)
        {
            if (wallposition.Direction == 0) //then wall is facing down.
            {
                game.Board[wallposition.XPos * 2][wallposition.YPos * 2 - 1] = BoardCellStatus.Wall;
                game.Board[wallposition.XPos * 2 + 2][wallposition.YPos * 2 - 1] = BoardCellStatus.Wall;
            }

            if (wallposition.Direction == 1)   //then wall is going right.
            {
                game.Board[wallposition.XPos * 2 - 1][wallposition.YPos * 2] = BoardCellStatus.Wall;
                game.Board[wallposition.XPos * 2 - 1][wallposition.YPos * 2 + 2] = BoardCellStatus.Wall;
            }

            return game;
        }

        public Game MovePlayer(PositionDb position, Game game)
        {
            var originalPosition = _playerRepository.GetPosition(position.PlayerId);
            game.Board[originalPosition.Horizontal*2][originalPosition.Vertical*2] = BoardCellStatus.NoPlayer;
            game.Board[position.XPos*2][position.YPos*2] = BoardCellStatus.Player1; // If loop to check which player is being moved
            return game;
        }

        public void UpdateBoardToSavedState(Game game)
        {
            var playerPositions = _positionRepository.GetByGame(game.Id).ToList();
            var listOfWalls = _wallRepository.GetByGameId(game.Id).ToList();

            foreach (var player in playerPositions)
            {
                game.Board[player.XPos*2][player.YPos*2] = BoardCellStatus.Player1; // Another if loop, to see which player to be moved.
            }

            foreach (var wall in listOfWalls)
            {
                if (wall.Direction == 0) //then wall is facing down.
                {
                    game.Board[wall.XPos * 2][wall.YPos * 2 - 1] = BoardCellStatus.Wall;
                    game.Board[wall.XPos * 2 + 2][wall.YPos * 2 - 1] = BoardCellStatus.Wall;
                }
                if (wall.Direction != 1) continue;
                game.Board[wall.XPos * 2 - 1][wall.YPos * 2] = BoardCellStatus.Wall;
                game.Board[wall.XPos * 2 - 1][wall.YPos * 2 + 2] = BoardCellStatus.Wall;
            }
        } 
    }
}