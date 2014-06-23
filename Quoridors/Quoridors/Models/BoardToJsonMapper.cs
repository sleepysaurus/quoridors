using System.Collections.Generic;
using System.Linq;
using Quoridors.Models.Database;

namespace Quoridors.Models
{
    public class BoardToJsonMapper
    {
        public List<Brick> GetListOfBricks(string[][] board)
        {
            var listOfBricks = new List<Brick>();

            for (var i = 0; i < board.Length; i++)
            {
                for (var z = 0; z < board.Length; z++)
                {
                    if (board[i][z] != "W") continue;
                    if (i%2 != 0 && z%2 != 0)
                    {
                        continue;
                    }

                    listOfBricks.Add(i%2 != 0
                        ? new Brick() {TopOrLeft = "top", XPos = i*2 - 1, YPos = i*2}
                        : new Brick() {TopOrLeft = "left", XPos = i*2, YPos = i*2 - 1});
                }
            }

            return listOfBricks;
        }

        public List<PositionJson> GetListOfPlayerPositions()
        {
            var positionRepo = new PositionRepository();
            var listOfPositionsFromRepo = positionRepo.All();

            return listOfPositionsFromRepo.Select(positon => new PositionJson() {PlayerId = positon.PlayerId, XPos = positon.XPos, YPos = positon.YPos}).ToList();
        }
    }
}