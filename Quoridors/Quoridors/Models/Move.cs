namespace Quoridors.Models
{
    public class Move
    {
        public int GameId { get; set; }
        public int PlayerNumber { get; set; }
        public Position NewPosition { get; set; }
    }
}