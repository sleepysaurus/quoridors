using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Database.Interfaces
{
    public interface IGameRepository : IRepository<GameDb>
    {
        GameDb CreateGame();
        GameDb GetById(int gameId);
    }
}