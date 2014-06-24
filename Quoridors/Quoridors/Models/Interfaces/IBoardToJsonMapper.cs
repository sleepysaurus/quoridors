using System.Collections.Generic;

namespace Quoridors.Models.Interfaces
{
    public interface IBoardToJsonMapper
    {
        Board CreateBoardObject(string[][] board);
        List<Brick> GetListOfBricks(string[][] board);
        List<PositionJson> GetListOfPlayerPositions();
    }
}