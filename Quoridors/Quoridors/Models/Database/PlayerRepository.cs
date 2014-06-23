using System.Collections.Generic;
using System.Data.SqlClient;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Database
{
    public class PlayerRepository : Repository<Player>
    {
        protected override Player NewModel(SqlDataReader reader)
        {
            return new Player
                (reader.GetString(reader.GetOrdinal("name")),
                reader.GetInt32(reader.GetOrdinal("game_id")));
        }

        protected Player CreatePlayer(Player toCreate)
        {
            ExecuteStoredProcedure("CreatePlayer", toCreate,
                new SqlParameter[] { new SqlParameter("@name", toCreate.Name), new SqlParameter("@game_id", toCreate.GameId) });
            toCreate.Id = GetLastId();
            return toCreate;
        }

        public override IEnumerable<Player> All()
        {
            return ExecuteReadStoredProcedure("GetAllPlayer", new SqlParameter[] {});
        }
    }
}