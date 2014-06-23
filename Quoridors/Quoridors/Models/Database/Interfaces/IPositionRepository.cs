using System.Collections.Generic;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Database.Interfaces
{
    public interface IPositionRepository
    {
        IEnumerable<PositionDb> GetByGame(int id);
    }
}