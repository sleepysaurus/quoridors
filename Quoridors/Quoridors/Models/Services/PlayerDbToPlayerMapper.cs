using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Interfaces;

namespace Quoridors.Models.Services
{
    public class PlayerDbToPlayerMapper : IPlayerDbToPlayerMapper
    {
        public Player MappingPlayer(PlayerDb playerDb)
        {
            return new Player(0,playerDb.Name, new Position(0,0));
        }
    }
}