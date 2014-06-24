using System.Collections.Generic;
using System.Linq;
using Microsoft.Ajax.Utilities;
using Quoridors.Models.Database;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int Turn { get; set; }
        public Player Winner { get; set; }
        public BoardCellStatus[][] Board { get; set; }
        public List<Player> Players { get; set; }

        public Game()
        {

            // TODO DRY this shit up
            // TODO do you want to do this every time a board is created, you'll end up with a new, empty board for every HttpRequest. You will need to do this somewhere? BoardFactory? Maybe?
            Board = new BoardCellStatus[][]{};
            for (int i = 0; i < 17; i++)
            {
                if (i%2 == 0)
                {
                    Board[i] = new[]
                    {
                        BoardCellStatus.Empty, BoardCellStatus.NoWall, BoardCellStatus.Empty, BoardCellStatus.NoWall,
                        BoardCellStatus.Empty, BoardCellStatus.NoWall, BoardCellStatus.Empty, BoardCellStatus.NoWall,
                        BoardCellStatus.Empty, BoardCellStatus.NoWall, BoardCellStatus.Empty,
                        BoardCellStatus.NoWall, BoardCellStatus.Empty, BoardCellStatus.NoWall, BoardCellStatus.Empty,
                        BoardCellStatus.NoWall, BoardCellStatus.Empty
                    };
                }
                if (i%2 == 1)
                {
                    for(int z =0; z < 17; z++)
                    {
                        Board[i][z] = BoardCellStatus.NoWall;
                    }
                }
            }

        }
    }
}