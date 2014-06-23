namespace Quoridors.Models.DatabaseModels
{
    public class Position
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int GameId { get; set; }

        public Position(int playerId, int xPos, int yPos, int gameId)
        {
            PlayerId = playerId;
            XPos = xPos;
            YPos = yPos;
            GameId = gameId;
        }
    }
}