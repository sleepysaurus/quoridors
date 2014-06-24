using System.Collections.Generic;

namespace Quoridors.Models.Interfaces
{
    public interface IBoardToJsonMapper
    {
        Board CreateBoardObject(BoardCellStatus[][] board);
        List<Brick> GetListOfBricks(BoardCellStatus[][] board);
        List<PositionJson> GetListOfPlayerPositions();
    }
}