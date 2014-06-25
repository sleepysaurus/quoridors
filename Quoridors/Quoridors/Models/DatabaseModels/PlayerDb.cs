namespace Quoridors.Models.DatabaseModels
{
    public class PlayerDb
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public int GameId { get; private set; }

        public PlayerDb(string name, int gameId, int id)
        {
            Name = name;
            GameId = gameId;
            Id = id;
        }
    }
}