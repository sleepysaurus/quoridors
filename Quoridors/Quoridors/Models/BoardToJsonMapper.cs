using System;
using System.Collections.Generic;
using System.Linq;
using Quoridors.Models.Database;
using Quoridors.Models.Interfaces;

namespace Quoridors.Models
{
    public class BoardToJsonMapper : IBoardToJsonMapper
    {
        public Board CreateBoardObject(string[][] board)
        {
           return new Board
            {
                ListOfBricks = GetListOfBricks(board),
                ListOfPlayerPositions = GetListOfPlayerPositions()
            };
        }

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

                    // i and z MIGHT be the wrong way around below
                    listOfBricks.Add(i%2 != 0
                        ? new Brick() {TopOrLeft = "top", XPos = (int) Math.Ceiling((decimal)i/2), YPos = z/2}
                        : new Brick() {TopOrLeft = "left", XPos = i/2, YPos = (int) Math.Ceiling((decimal)z/2)});
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