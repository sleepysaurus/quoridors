using System.Collections.Generic;

namespace Quoridors.Models.Interfaces
{
    public interface IGameFactory
    {
        Game New(IEnumerable<string> playerName);
        Game Load(int gameId);
    }
}