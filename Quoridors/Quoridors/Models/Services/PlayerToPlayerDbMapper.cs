using System.Linq;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Interfaces;

namespace Quoridors.Models.Services
{
    public class PlayerToPlayerDbMapper : IPlayerToPlayerDbMapper
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;

        public PlayerToPlayerDbMapper(IGameRepository gameRepository, IPlayerRepository playerRepository)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
        }

        public PlayerDb GetPlayerDb(Player player)
        {
            var playerDb = _playerRepository.All().Single(x => x.Id == player.Id);
            var gameId = _gameRepository.GetById(playerDb.GameId).Id;
            return new PlayerDb(player.PlayerName, gameId ,player.Id);
        }
    }
}