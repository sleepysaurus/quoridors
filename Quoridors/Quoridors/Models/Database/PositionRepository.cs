using System.Collections.Generic;
using System.Data.SqlClient;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Database
{
    public class PositionRepository : Repository<Position>
    {
        protected override Position NewModel(SqlDataReader reader)
        {
            return new Position
                (reader.GetInt32(reader.GetOrdinal("player_id")),
                reader.GetInt32(reader.GetOrdinal("x_pos")),
                reader.GetInt32(reader.GetOrdinal("y_pos")),
                reader.GetInt32(reader.GetOrdinal("game_id")));
        }

        protected Position Update(Position toUpdate)
        {
            ExecuteStoredProcedure("CreatePlayer", toUpdate,
                new SqlParameter[] { new SqlParameter("@PlayerId", toUpdate.Id), new SqlParameter("@XPos", toUpdate.XPos), new SqlParameter("@YPos", toUpdate.YPos)});
            toUpdate.Id = GetLastId();
            return toUpdate;
        }

        public override IEnumerable<Position> All()
        {
            return ExecuteReadStoredProcedure("GetAllPosition", new SqlParameter[] {});
        }
    }
}