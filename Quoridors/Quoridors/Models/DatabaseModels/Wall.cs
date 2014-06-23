namespace Quoridors.Models.DatabaseModels
{
    public class Wall
    {
        public int Id { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int Direction { get; set; }
        public int GameId { get; set; }

        public Wall(int xPos, int yPos, int direction, int gameId)
        {
            XPos = xPos;
            YPos = yPos;
            Direction = direction;
            GameId = gameId;
        }
    }
}