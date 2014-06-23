using Quoridors.Models.Database;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models
{
    public class JsonToBoardMapper
    {
        public string[][] AddWall(Wall wall, string[][] board)
        {
            var xPos = wall.Origin.Horizontal;
            var yPos = wall.Origin.Vertical;
            var direction = wall.Direction;

            board[xPos][yPos] = "W";

            if (direction == Direction.Down)
            {
                board[xPos][yPos + 1] = "W";
                board[xPos][yPos + 2] = "W";
            }
            else
            {
                board[xPos + 1][yPos] = "W";
                board[xPos + 2][yPos] = "W";
            }
        }

        public string[][] MovePlayer(Move move, string[][] board)
        {
            var originalPosition = new PlayerRepository().GetPosition(move.PlayerNumber);
            board[originalPosition.Horizontal][originalPosition.Vertical] = "0";
            board[move.NewPosition.Horizontal][move.NewPosition.Vertical] = "1";
        }
    }
}