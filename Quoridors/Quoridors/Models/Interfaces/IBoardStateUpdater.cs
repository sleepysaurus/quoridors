using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Interfaces
{
    public interface IBoardStateUpdater
    {
        Game AddWall(WallDb wallposition, Game game);
        void UpdateBoardToSavedState(Game game);
        Game MovePlayer(PositionDb position, Game game);
        void CheckWall(WallDb wallposition);
    }
}