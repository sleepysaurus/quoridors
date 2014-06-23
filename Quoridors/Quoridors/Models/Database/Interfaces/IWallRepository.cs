using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Database.Interfaces
{
    public interface IWallRepository : IRepository<WallDb>
    {
        WallDb CreateWall(WallDb toCreate);
    }
}