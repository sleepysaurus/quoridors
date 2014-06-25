using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Services
{
    public interface IPlayerToPlayerDbMapper
    {
        PlayerDb GetPlayerDb(Player player);
    }
}