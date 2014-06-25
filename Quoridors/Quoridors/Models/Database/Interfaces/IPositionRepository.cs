using System.Collections.Generic;
using System.Data.SqlClient;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Database
{
    public interface IPositionRepository : IRepository<PositionDb>
    {
        PositionDb NewModel(SqlDataReader reader);
        PositionDb Create(PositionDb toCreate);
        PositionDb Update(PositionDb toUpdate);
        PositionDb GetPositionByPlayerId(int playerId);
        IEnumerable<PositionDb> All();
        IEnumerable<PositionDb> GetPositionByGameId(int id);
    }
}