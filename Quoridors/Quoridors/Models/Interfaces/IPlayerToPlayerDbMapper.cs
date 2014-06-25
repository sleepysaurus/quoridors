using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Interfaces
{
    public interface IPlayerToPlayerDbMapper
    {
        PlayerDb GetPlayerDb(Player player);
    }
}