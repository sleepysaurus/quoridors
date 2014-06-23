using System.Collections.Generic;
using System.Data.SqlClient;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models.Database
{
    public class GameRepository : Repository<Game>
    {
        protected override Game NewModel(SqlDataReader reader)
        {
            return new Game();
        }

        protected int CreateGame()
        {
            ExecuteStoredProcedure("CreateGame", new Game(), new SqlParameter[]{});
            return GetLastId();
        }

        public override IEnumerable<Game> All()
        {
            return ExecuteReadStoredProcedure("GetAllGame", new SqlParameter[]{});
        }
    }
}