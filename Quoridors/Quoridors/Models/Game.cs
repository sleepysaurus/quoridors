using System.Collections.Generic;
using System.Linq;
using Quoridors.Models.Database;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models
{
    public class Game
    {
        public int Turn { get; set; }
        public Player Winner { get; set; }
        public string[][] Board { get; set; }
        private readonly PositionRepository _positionRepository = new PositionRepository();
        private readonly WallRepository _wallRepository = new WallRepository();

        public Game()
        {
            // TODO DRY this shit up
            Board = new[]
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

        public List<PositionDb> GetPlayerPositions(int gameId)
        {         
            var positions = _positionRepository.All(); 
            return positions.Where(player => player.GameId == gameId).ToList();
        }

        public List<WallDb> GetWallPositions(int gameId)
        {
            var walls = _wallRepository.All();
            return walls.Where(wall => wall.GameId == gameId).ToList();
        }

        // Why do we need this method?
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
    }
}