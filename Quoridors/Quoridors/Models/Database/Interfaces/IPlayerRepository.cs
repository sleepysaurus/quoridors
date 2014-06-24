using System.Collections.Generic;
using System.Data.SqlClient;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Database.Interfaces
{
    public interface IPlayerRepository
    {
        PlayerDb NewModel(SqlDataReader reader);
        PlayerDb CreatePlayer(PlayerDb toCreate);
        IEnumerable<PlayerDb> All();
        PositionDb GetPosition(int playerId);
        void ExecuteStoredProcedure(string procedureName, PlayerDb thingToDoStuffWith, SqlParameter[] parameters);
        IEnumerable<PlayerDb> ExecuteReadStoredProcedure(string procedureName, SqlParameter[] parameters);
        void ExecuteNonQuery(string query);
        int GetLastId();
        IEnumerable<PlayerDb> ExecuteRead(string query);
        void Dispose();
    }
}