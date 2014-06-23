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

        public List<PositionDb> GetPlayerPositions(int gameID)
        {
            
            var positions = _positionRepository.All(); 
            return positions.Where(player => player.GameId == gameID).ToList();
        }

        public List<WallDb> GetWallPositions(int gameID)
        {
            var walls = _wallRepository.All();
            return walls.Where(wall => wall.GameId == gameID).ToList();
        }

        public void UpdateBoard(List<PositionDb> playerPositions, List<WallDb> wallPositions)
        {
            foreach (var player in playerPositions)
            {
                Board[player.XPos*2+1][player.YPos*2+1] = player.Id.ToString();
            }

            foreach (var wall in wallPositions)
            {
                if (wall.Direction == 0) //then wall is facing down.
                {
                    Board[wall.XPos*2 + 1][wall.YPos*2] = "W";
                    Board[wall.XPos*2 + 3][wall.YPos*2] = "W";
                }
                if (wall.Direction == 1)   //then wall is going right.
                {
                    Board[wall.XPos*2][wall.YPos*2 + 1] = "W";
                    Board[wall.XPos*2][wall.YPos*2 + 3] = "W";
                }
            }
        }

        //receives response from game
        //checks validity of player position
        //checks validity of wall position
        //adds new wall or player to model
        public void updatePlayerPositionModel(PositionDb position)
        {
            Board[position.XPos*2+1][position.YPos*2+1] = position.PlayerId.ToString();
        }

        public void updateWallPositionModel(WallDb wallposition)
        {
            if (wallposition.Direction == 0) //then wall is facing down.
            {
                Board[wallposition.XPos * 2 + 1][wallposition.YPos * 2] = "W";
                Board[wallposition.XPos * 2 + 3][wallposition.YPos * 2] = "W";
            }
            if (wallposition.Direction == 1)   //then wall is going right.
            {
                Board[wallposition.XPos * 2][wallposition.YPos * 2 + 1] = "W";
                Board[wallposition.XPos * 2][wallposition.YPos * 2 + 3] = "W";
            }
        }

        //update repo....???
        public void updatePlayerPositionDB(PositionDb position)
        {
            _positionRepository.Update //protected..?
        }

        public void updateWallPositionDB(WallDb wallposition)
        {
            _wallRepository.Update //protected..?
        }
    }
}