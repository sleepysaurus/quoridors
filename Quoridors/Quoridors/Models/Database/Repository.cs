using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Quoridors.Models.Database
{
    public abstract class Repository<T> : IDisposable
    {
        public abstract IEnumerable<T> All();

        protected Repository()
        {
            _connection = new SqlConnection(@ConfigurationManager.AppSettings["Connection-String"]);
            _connection.Open();
            _command = new SqlCommand("", _connection);
        }

        protected void ExecuteStoredProcedure(string procedureName, T thingToDoStuffWith, SqlParameter[] parameters)
        {
            _command.CommandText = procedureName;
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddRange(parameters);
            _command.ExecuteNonQuery();
        }

        protected IEnumerable<T> ExecuteReadStoredProcedure(string procedureName, SqlParameter[] parameters)
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

        protected void ExecuteNonQuery(string query)
        {
            _command.CommandText = query;
            _command.ExecuteNonQuery();
        }

        protected int GetLastId()
        {
            _command.CommandText = "SELECT @@IDENTITY as [identity];";
            using (var reader = _command.ExecuteReader())
            {
                reader.Read();
                return int.Parse(reader[0].ToString());
            }
        }

        protected IEnumerable<T> ExecuteRead(string query)
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

        protected abstract T NewModel(SqlDataReader reader);

        public void Dispose()
        {
            if (_connection.State != ConnectionState.Open) return;
            _connection.Close();
            _connection.Dispose();
        }
    }
}