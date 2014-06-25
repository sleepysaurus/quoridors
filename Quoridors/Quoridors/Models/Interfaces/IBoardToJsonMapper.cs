using System.Collections.Generic;

namespace Quoridors.Models.Interfaces
{
    public interface IBoardToJsonMapper
    {
        BoardToJson CreateBoardObject(Game game);
        List<Brick> GetListOfBricks(Game game);
        List<PositionJson> GetListOfPlayerPositions(int gameId);
    }
}