namespace Quoridors.Models.DatabaseModels
{
    public class PositionDb
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int GameId { get; set; }

        public PositionDb()
        {
        }

        public PositionDb(int playerId, int xPos, int yPos, int gameId)
        {
            PlayerId = playerId;
            XPos = xPos;
            YPos = yPos;
            GameId = gameId;
        }
    }
}