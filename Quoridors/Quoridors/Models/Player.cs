using System;

namespace Quoridors.Models
{
    [Serializable]
    public class Player
    {
        public int PlayerNumber { get; set; }
        public Position Position { get; set; }
        public string PlayerName { get; set; }

        public Player(int playerNumber, string playerName)// BA do you want starting positions every time you construct a new player? Should you be passing positions in?
        {
            PlayerNumber = playerNumber;
            PlayerName = playerName;

            if (PlayerNumber == 1)
            {
                Position = new Position(4, 8);
            }
            if (PlayerNumber == 2)
            {
                Position = new Position(4, 0);
            }
        }
    }
}