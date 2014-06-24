using System;
using System.Collections.Generic;
using System.Linq;
using Quoridors.Models.Database;
using Quoridors.Models.Interfaces;

namespace Quoridors.Models.Services
{
    public class BoardToJsonMapper : IBoardToJsonMapper
    {
        public Board CreateBoardObject(BoardCellStatus[][] board)
        {
           return new Board
            {
                ListOfBricks = GetListOfBricks(board),
                ListOfPlayerPositions = GetListOfPlayerPositions()
            };
        }

        public List<Brick> GetListOfBricks(BoardCellStatus[][] board)
        {
            var listOfBricks = new List<Brick>();

            for (var i = 0; i < board.Length; i++)
            {
                for (var z = 0; z < board.Length; z++)
                {
                    if (board[i][z] != BoardCellStatus.Wall) continue;
                    if (i%2 != 0 && z%2 != 0)
                    {
                        continue;
                    }

                    // i and z MIGHT be the wrong way around below
                    listOfBricks.Add(i%2 != 0
                        ? new Brick( (int) Math.Ceiling((decimal)i/2),  z/2, "top")
                        : new Brick(i/2, (int) Math.Ceiling((decimal)z/2), "left")); // BA should these be strings? (Question not leading question :))
                }
            }

            return listOfBricks;
        }

        public List<PositionJson> GetListOfPlayerPositions()
        {
            var positionRepo = new PositionRepository(); // BA move to constructor
            var listOfPositionsFromRepo = positionRepo.All();

            return listOfPositionsFromRepo.Select(positon => new PositionJson() {PlayerId = positon.PlayerId, XPos = positon.XPos, YPos = positon.YPos}).ToList();
        }
    }
}