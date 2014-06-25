using System;
using System.Collections.Generic;
using System.Linq;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Interfaces;

namespace Quoridors.Models.Services
{
    // BA clean this class up
    public class GameFactory : IGameFactory
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGameDbMapperToGame _dbMapperToGame;
        private readonly IBoardFactory _boardFactory;
        private readonly IPlayerRepository _playerRepository;
        private readonly IPlayerDbToPlayerMapper _playerDbToPlayerMapper;
        private readonly Dictionary<int, Position> _startingPositions = new Dictionary<int, Position>
        {
            { 1, new Position(4,8)},
            { 2, new Position(4,0)},
            { 3, new Position(0,4)},
            { 4, new Position(8,4)}

        };

        public GameFactory(IGameRepository gameRepository, IGameDbMapperToGame dbMapperToGame, IBoardFactory boardFactory, IPlayerRepository playerRepository, IPlayerDbToPlayerMapper playerDbToPlayerMapper)
        {
            _gameRepository = gameRepository;
            _dbMapperToGame = dbMapperToGame;
            _boardFactory = boardFactory;
            _playerRepository = playerRepository;
            _playerDbToPlayerMapper = playerDbToPlayerMapper;
        }

        public Game New(IEnumerable<string> playerNames) 
        {
            if (playerNames.Count() > 4)
            {
                throw new ArgumentOutOfRangeException("4 players maximum old boy");
            }


            var gameId = _gameRepository.CreateGame().Id;

            var players = new List<Player>();
            int playerNumber = 1;
            foreach (var playerName in playerNames)
            {
                var player = new PlayerDb(playerName, gameId, 0);
                var playerDb = _playerRepository.CreatePlayer(player);
                var mappedPlayer = _playerDbToPlayerMapper.MappingPlayer(playerDb); // TODO map playerdbs to players

                mappedPlayer.Position = _startingPositions[playerNumber]; // // TODO figure out player starting positions
                mappedPlayer.PlayerNumber = playerNumber;
                mappedPlayer.Id = playerDb.Id;
                players.Add(mappedPlayer);
                
                playerNumber++;
            }

            var game = new Game(players, _boardFactory.CreateBoard(), gameId); 
            
            //save to new game db
            return game;
        }

        public Game Load(int gameId)
        {
            var gameDb = _gameRepository.GetById(gameId);
            var game = _dbMapperToGame.MappingGameFromDatabase(gameDb);
            return game;
        }
    }
}