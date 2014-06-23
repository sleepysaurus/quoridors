using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quoridors.Models
{
    [Serializable]
    public class Player
    {
        public int PlayerNumber { get; set; }
        public Position Position { get; set; }
        public string PlayerName { get; set; }

        public Player(int playerNumber, string playerName)
        {
            PlayerNumber = playerNumber;
            PlayerName = playerName;

            if (PlayerNumber == 1)
            {
                Position = new Position(){Horizontal = 4, Vertical = 8};
            }
            if (PlayerNumber == 2)
            {
                Position = new Position(){Horizontal = 4, Vertical = 0};
            }
        }
    }
}