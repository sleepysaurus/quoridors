using System.Collections.Generic;

namespace Quoridors.Models.Interfaces
{
    public interface IBoardToJsonMapper
    {
        BoardToJson CreateBoardObject(BoardCellStatus[][] board, Game game);
        List<Brick> GetListOfBricks(BoardCellStatus[][] board);
        List<PositionJson> GetListOfPlayerPositions();
    }
}