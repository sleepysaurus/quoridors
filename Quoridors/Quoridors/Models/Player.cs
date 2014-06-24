using System;

namespace Quoridors.Models
{
    [Serializable]
    public class Player
    {
        public int PlayerNumber { get; set; }
        public Position Position { get; set; }
        public string PlayerName { get; set; }
        
        public Player(int playerNumber, string playerName, Position position)
        {
            PlayerNumber = playerNumber;
            PlayerName = playerName;
            Position = position;
        }
    }
}