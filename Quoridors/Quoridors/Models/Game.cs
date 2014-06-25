using System.Collections.Generic;
using Quoridors.Models.Services;
using Quoridors.Models.Database.Interfaces;

namespace Quoridors.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int Turn { get; set; }
        public Player Winner { get; set; }
        public BoardCellStatus[][] Board { get; set; }
        public List<Player> Players { get; set; }

        public Game(Player player1, Player player2, BoardCellStatus[][] board, int gameId) // BA called by GameFactory for new games
        {
            Players = new List<Player> {player1, player2};
            Board = board;
            Id = gameId;
            Turn = 1;
        }

        public Game(int id, int turn, BoardCellStatus[][] board ) // BA called by board db mapper
        {
            Id = id;
            Turn = turn;
            Board = board;
            Players = new List<Player>();
        }        
    }
}