using System.Linq;
using Quoridors.Models.Database;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models
{
    public interface IBoardStateUpdater
    {
        Game AddWall(WallDb wallposition, Game game);
        Game MovePlayer(Move move, Game game);
        void UpdateBoardToSavedState(Game game);
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
                game.Board[wallposition.XPos * 2 + 1][wallposition.YPos * 2] = "W";
                game.Board[wallposition.XPos * 2 + 3][wallposition.YPos * 2] = "W";
            }

            if (wallposition.Direction == 1)   //then wall is going right.
            {
                game.Board[wallposition.XPos * 2][wallposition.YPos * 2 + 1] = "W";
                game.Board[wallposition.XPos * 2][wallposition.YPos * 2 + 3] = "W";
            }

            return game;
        }

        public Game MovePlayer(Move move, Game game)
        {
            var originalPosition = new PlayerRepository().GetPosition(move.PlayerNumber);
            game.Board[originalPosition.Horizontal][originalPosition.Vertical] = "0";
            game.Board[move.NewPosition.Horizontal][move.NewPosition.Vertical] = "1";
            return game;
        }

        // Why do we need this method? BA Probs to get the board back from empty into the current state 
        public void UpdateBoardToSavedState(Game game)
        {
            var playerPositions = _positionRepository.GetByGame(game.Id).ToList();// TODO add an Id to Game

            var wallPositions = _wallRepository.All().Where(wall => wall.GameId ==game.Id).ToList(); ; // TODO add a GetById to wallRepository


            foreach (var player in playerPositions)
            {
                game.Board[player.XPos * 2 + 1][player.YPos * 2 + 1] = player.Id.ToString();
            }

            foreach (var wall in wallPositions)
            {
                if (wall.Direction == 0) //then wall is facing down.
                {
                    game.Board[wall.XPos * 2 + 1][wall.YPos * 2] = "W";
                    game.Board[wall.XPos * 2 + 3][wall.YPos * 2] = "W";
                }
                if (wall.Direction == 1)   //then wall is going right.
                {
                    game.Board[wall.XPos * 2][wall.YPos * 2 + 1] = "W";
                    game.Board[wall.XPos * 2][wall.YPos * 2 + 3] = "W";
                }
            }
        } 
    }
}