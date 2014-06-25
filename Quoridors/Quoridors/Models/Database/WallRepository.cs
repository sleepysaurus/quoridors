using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Database
{
    public class WallRepository : Repository<WallDb>, IWallRepository
    {
        public override WallDb NewModel(SqlDataReader reader)
        {
            return new WallDb
                (reader.GetInt32(reader.GetOrdinal("x_pos")),
                reader.GetInt32(reader.GetOrdinal("y_pos")),
                reader.GetInt32(reader.GetOrdinal("direction")),
                reader.GetInt32(reader.GetOrdinal("game_id")));
        }

        public WallDb CreateWall(WallDb toCreate)
        {
            ExecuteStoredProcedure("CreateWall", toCreate,
                new SqlParameter[] { new SqlParameter("@XPos", toCreate.XPos), new SqlParameter("@YPos", toCreate.YPos), 
                new SqlParameter("@Direction", toCreate.Direction), new SqlParameter("@GameId", toCreate.GameId) });
            var list = ExecuteReadStoredProcedure("GetAllWall", new SqlParameter[] { });
            toCreate.Id = list.Last().Id;
            return toCreate;
        }

        public override IEnumerable<WallDb> All()
        {
            return ExecuteReadStoredProcedure("GetAllWall", new SqlParameter[] { });
        }

        public List<WallDb> GetWallByGameId(int gameId)
        {
            return ExecuteReadStoredProcedure("GetWallByGameId", new SqlParameter[] { new SqlParameter("@game_id", gameId) }).ToList();
        }
    }
}