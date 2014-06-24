using System.Collections.Generic;

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
            Board = new BoardCellStatus[17][];
            CreateBoard();
        }

        public void CreateBoard()
        {
            for (var i = 0; i < 17; i++)
            {
                Board[i] = new BoardCellStatus[17];
                if (i % 2 == 0)
                {
                    for (var z = 0; z < 17; z++)
                    {
                        if (z%2 == 0)
                        {
                            Board[i][z] = BoardCellStatus.NoPlayer;
                        }
                        else
                        {
                            Board[i][z] = BoardCellStatus.NoWall;
                        }
                    }
                }
                if (i % 2 == 1)
                {
                    for (int z = 0; z < 17; z++)
                    {
                        Board[i][z] = BoardCellStatus.NoWall;
                    }
                }
            }
        }
    }
}