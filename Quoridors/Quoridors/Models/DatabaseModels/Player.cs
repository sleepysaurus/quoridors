namespace Quoridors.Models.DatabaseModels
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }

        public Player(string name, int gameId)
        {
            Name = name;
            GameId = gameId;
        }
    }
}