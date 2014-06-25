using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Quoridors.Models.Database.Interfaces;

namespace Quoridors.Models.Database
{
    public abstract class Repository<T> : IRepository<T>
    {
        public abstract IEnumerable<T> All();

        protected Repository()
        {
            _connection = new SqlConnection(@ConfigurationManager.AppSettings["Connection-String"]);
            _connection.Open();
            _command = new SqlCommand("", _connection);
        }

        public void ExecuteStoredProcedure(string procedureName, T thingToDoStuffWith, SqlParameter[] parameters)
        {
            _command.CommandText = procedureName;
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddRange(parameters);
            _command.ExecuteNonQuery();
            _command.Parameters.Clear();
        }

        public IEnumerable<T> ExecuteReadStoredProcedure(string procedureName, SqlParameter[] parameters)
        {
            _command.CommandText = procedureName;
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddRange(parameters);

            var result = new List<T>();
            using (var reader = _command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(NewModel(reader));
                }
                return result;
            }
        }

        private readonly SqlConnection _connection;
        private readonly SqlCommand _command;

        public void ExecuteNonQuery(string query)
        {
            _command.CommandText = query;
            _command.ExecuteNonQuery();
        }

        public int GetLastId()
        {
            _command.CommandText = "SELECT @@IDENTITY as [identity];";
            using (var reader = _command.ExecuteReader())
            {
                reader.Read();
                return int.Parse(reader[0].ToString());
            }
        }

        public IEnumerable<T> ExecuteRead(string query)
        {
            _command.CommandText = query;

            var result = new List<T>();
            using (var reader = _command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(NewModel(reader));
                }
                return result;
            }
        }

        public abstract T NewModel(SqlDataReader reader);

        public void Dispose()
        {
            if (_connection.State != ConnectionState.Open) return;
            _connection.Close();
            _connection.Dispose();
        }
    }
}