using System.Collections.Generic;
using System.Data.SqlClient;

namespace Quoridors.Models.Database.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> All();
        void ExecuteStoredProcedure(string procedureName, T thingToDoStuffWith, SqlParameter[] parameters);
        IEnumerable<T> ExecuteReadStoredProcedure(string procedureName, SqlParameter[] parameters);
        void ExecuteNonQuery(string query);
        IEnumerable<T> ExecuteRead(string query);
        T NewModel(SqlDataReader reader);
    }
}