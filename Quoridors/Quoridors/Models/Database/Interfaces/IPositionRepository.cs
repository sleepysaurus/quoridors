using System.Collections.Generic;
using System.Data.SqlClient;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Database
{
    public interface IPositionRepository
    {
        PositionDb NewModel(SqlDataReader reader);
        PositionDb Update(PositionDb toUpdate);
        IEnumerable<PositionDb> All();
        IEnumerable<PositionDb> GetByGame(int id);
    }
}