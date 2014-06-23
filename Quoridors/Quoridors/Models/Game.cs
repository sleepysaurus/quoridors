using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Quoridors.Models.Database;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models
{
    public class Game
    {
        public int Turn { get; set; }
        public Player Winner { get; set; }
        public string[][] Board { get; set; }
        
        private PlayerRepository _playerRepository = new PlayerRepository();
        private PositionRepository _positionRepository = new PositionRepository();
        private WallRepository _wallRepository = new WallRepository();

        public Game()
        {
            Board = new string[][]
            {
                new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"}
            };
        }

        public Dictionary<int, Position> GetPlayerPositions(int gameID)
        {
            
            var positions = _positionRepository.All();      //currently, this will probably get all of the positions.Ever.For ALL players. Need to figure out how to get gameID data.
            
            var listofPlayersPositions = new Dictionary<int, Position>();
            foreach (var player in positions) //where player.GameId == gameID
            {
                if (player.GameId == gameID)
                {
                    listofPlayersPositions.Add(player.PlayerId, new Position(player.XPos, player.YPos));
                }
            }
            //var player1 = positions.PlayerId;
            

            //get from repo all of the players on current board.
            return listofPlayersPositions;
        }

        public void GetWallPositions(int gameID)
        {

        }

        public void UpdateBoard()
        {
            
        }

    }
}