namespace Quoridors.Models.Interfaces
{
    public interface IGameFactory
    {
        Game New();
        Game Load(int gameId);
    }
}