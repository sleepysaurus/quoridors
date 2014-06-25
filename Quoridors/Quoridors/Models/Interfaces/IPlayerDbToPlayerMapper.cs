using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Interfaces
{
    public interface IPlayerDbToPlayerMapper
    {
        Player MappingPlayer(PlayerDb playerDb);
    }
}