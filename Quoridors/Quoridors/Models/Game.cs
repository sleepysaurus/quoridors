﻿using System.Collections.Generic;

namespace Quoridors.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int Turn { get; set; }
        public Player Winner { get; set; }
        public BoardCellStatus[][] Board { get; set; }
        public IEnumerable<Player> Players { get; set; }

        public Game(IEnumerable<Player> players,BoardCellStatus[][] board, int gameId) // BA called by GameFactory for new games
        {
            Players = players;
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