using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Services
{
    public interface IPlayerDbToPlayerMapper
    {
        Player MappingPlayer(PlayerDb playerDb);
    }
}