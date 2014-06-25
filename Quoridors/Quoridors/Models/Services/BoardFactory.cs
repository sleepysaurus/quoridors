using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quoridors.Models.Services
{
    public class BoardFactory : IBoardFactory
    {
        public BoardCellStatus[][] CreateBoard() // BA pull this out into a BoardCreator / BoardFactory which returns a board & call from gamefactory
        {
            var board = new BoardCellStatus[17][];
            for (var i = 0; i < 17; i++)
            {
                board[i] = new BoardCellStatus[17];
                if (i % 2 == 0)
                {
                    for (var z = 0; z < 17; z++)
                    {
                        if (z % 2 == 0)
                        {
                            board[i][z] = BoardCellStatus.NoPlayer;
                        }
                        else
                        {
                            board[i][z] = BoardCellStatus.NoWall;
                        }
                    }
                }
                if (i % 2 == 1)
                {
                    for (int z = 0; z < 17; z++)
                    {
                        board[i][z] = BoardCellStatus.NoWall;
                    }
                }
            }
            return board;
        }
    }
}