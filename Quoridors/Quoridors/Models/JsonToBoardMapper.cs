using Quoridors.Models.Database;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models
{
    public class JsonToBoardMapper
    {
        public string[][] AddWall(WallDb wallposition, string[][] board)
        {
            if (wallposition.Direction == 0) //then wall is facing down.
            {
                board[wallposition.XPos * 2 + 1][wallposition.YPos * 2] = "W";
                board[wallposition.XPos * 2 + 3][wallposition.YPos * 2] = "W";
            }

            if (wallposition.Direction == 1)   //then wall is going right.
            {
                board[wallposition.XPos * 2][wallposition.YPos * 2 + 1] = "W";
                board[wallposition.XPos * 2][wallposition.YPos * 2 + 3] = "W";
            }

            return board;
        }

        public string[][] MovePlayer(Move move, string[][] board)
        {
            var originalPosition = new PlayerRepository().GetPosition(move.PlayerNumber);
            board[originalPosition.Horizontal][originalPosition.Vertical] = "0";
            board[move.NewPosition.Horizontal][move.NewPosition.Vertical] = "1";
            return board;
        }
    }
}