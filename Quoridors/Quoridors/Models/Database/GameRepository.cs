using System.Collections.Generic;
using System.Data.SqlClient;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Database
{
    public class GameRepository : Repository<GameDb>
    {
        protected override GameDb NewModel(SqlDataReader reader)
        {
            return new GameDb();
        }

        protected int CreateGame()
        {
            ExecuteStoredProcedure("CreateGame", new GameDb(), new SqlParameter[]{});
            return GetLastId();
        }

        public override IEnumerable<GameDb> All()
        {
            return ExecuteReadStoredProcedure("GetAllGame", new SqlParameter[]{});
        }
    }
}