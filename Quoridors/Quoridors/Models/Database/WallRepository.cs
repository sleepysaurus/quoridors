using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            toCreate.Id = GetLastId();
            return toCreate;
        }

        public override IEnumerable<WallDb> All()
        {
            return ExecuteReadStoredProcedure("GetAllWall", new SqlParameter[] { });
        }

        // ToDo Add a get by game id method that takes gameId as parameter
        public List<WallDb> GetByGameId(int gameId)
        {
            throw new NotImplementedException();
        }
    }
}