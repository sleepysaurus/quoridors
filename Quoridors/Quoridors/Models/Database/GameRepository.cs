using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Database
{
    public class GameRepository : Repository<GameDb>, IGameRepository
    {
        public override GameDb NewModel(SqlDataReader reader)
        {
            var id = reader.GetInt32(reader.GetOrdinal("Id"));
            return new GameDb(){Id=id,Turn = 0};
        }

        public GameDb CreateGame()
        {
            var q = ExecuteReadStoredProcedure("CreateGame", new SqlParameter[] { });
            return q.Single();
        }

        public GameDb GetById(int gameId)
        {
            return ExecuteReadStoredProcedure("GetGameById", new SqlParameter[] { new SqlParameter("@game_id",gameId), }).First(); // BA use .Single()
        }

        public override IEnumerable<GameDb> All()
        {
            return ExecuteReadStoredProcedure("GetAllGame", new SqlParameter[]{});
        }

    }
}