using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Database
{
    public class PlayerRepository : Repository<PlayerDb>, IPlayerRepository
    {
        public override PlayerDb NewModel(SqlDataReader reader)
        {
            return new PlayerDb
                (reader.GetString(reader.GetOrdinal("name")),
                reader.GetInt32(reader.GetOrdinal("game_id")));
        }

        public PlayerDb CreatePlayer(PlayerDb toCreate)
        {
            ExecuteStoredProcedure("CreatePlayer", toCreate,
                new SqlParameter[] { new SqlParameter("@name", toCreate.Name), new SqlParameter("@game_id", toCreate.GameId) });
            toCreate.Id = GetLastId();
            return toCreate;
        }

        public override IEnumerable<PlayerDb> All()
        {
            return ExecuteReadStoredProcedure("GetAllPlayer", new SqlParameter[] {});
        }

        public PositionDb GetPosition(int playerId)
        {
            throw new NotImplementedException();
        }
    }
}