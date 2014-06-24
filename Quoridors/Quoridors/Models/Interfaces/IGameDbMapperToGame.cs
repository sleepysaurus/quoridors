using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Interfaces
{
    public interface IGameDbMapperToGame
    {
        Game MappingGameFromDatabase(GameDb gameDb);
    }
}