using System.Collections.Generic;
using System.Data.SqlClient;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Database
{
    public class PositionRepository : Repository<PositionDb>, IPositionRepository
    {
        public override PositionDb NewModel(SqlDataReader reader)
        {
            return new PositionDb
                (reader.GetInt32(reader.GetOrdinal("player_id")),
                reader.GetInt32(reader.GetOrdinal("x_pos")),
                reader.GetInt32(reader.GetOrdinal("y_pos")),
                reader.GetInt32(reader.GetOrdinal("game_id")));
        }

        public PositionDb Create(PositionDb toCreate)
        {
            ExecuteStoredProcedure("CreatePosition", toCreate,
                new SqlParameter[]
                {
                    new SqlParameter("@PlayerId", toCreate.PlayerId), new SqlParameter("@XPos", toCreate.XPos),
                    new SqlParameter("@YPos", toCreate.YPos), new SqlParameter("@GameID", toCreate.GameId),
                });
            // toUpdate.Id = GetLastId();
            return toCreate;
        }

        public PositionDb Update(PositionDb toUpdate)
        {
            ExecuteStoredProcedure("UpdatePosition", toUpdate,
                new SqlParameter[]
                {
                    new SqlParameter("@PlayerId", toUpdate.PlayerId), new SqlParameter("@XPos", toUpdate.XPos),
                    new SqlParameter("@YPos", toUpdate.YPos), new SqlParameter("@GameID", toUpdate.GameId),
                });
           // toUpdate.Id = GetLastId();
            return toUpdate;
        }

        public override IEnumerable<PositionDb> All()
        {
            return ExecuteReadStoredProcedure("GetAllPosition", new SqlParameter[] {});
        } 


        public  IEnumerable<PositionDb> GetByGame(int id)
        {
            return ExecuteReadStoredProcedure("GetByGame", new SqlParameter[] {new SqlParameter("gameid",id) });
        }
    }
}