namespace Quoridors.Models.DatabaseModels
{
    public class PlayerDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }

        public PlayerDb(string name, int gameId)
        {
            Name = name;
            GameId = gameId;
        }
    }
}