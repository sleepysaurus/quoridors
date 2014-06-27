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

        private SqlCommand CreateCommand(string procName, SqlConnection connection)
        {
            var command = new SqlCommand(procName, connection) {CommandType = CommandType.StoredProcedure};
            return command;
        }

        public SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(@ConfigurationManager.AppSettings["Connection-String"]);
            connection.Open();
            return connection;
        }

        public void ExecuteStoredProcedure(string procedureName, T thingToDoStuffWith, SqlParameter[] parameters)
        {
            using (var connection = CreateConnection())
            {
                using (var command = CreateCommand(procedureName, connection))
                {
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
            
        }

        public IEnumerable<T> ExecuteReadStoredProcedure(string procedureName, SqlParameter[] parameters)
        {
            using (var connection = CreateConnection())
            using (var command = CreateCommand(procedureName, connection))
            {
                command.Parameters.AddRange(parameters);

                var result = new List<T>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(NewModel(reader));
                    }
                    return result;
                }
            }
        }


        public void ExecuteNonQuery(string query)
        {
            using (var connection = CreateConnection())
            using (var command = CreateCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<T> ExecuteRead(string query)
        {
            using (var connection = CreateConnection())
            using (var command = CreateCommand(query, connection))
            {
                var result = new List<T>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(NewModel(reader));
                    }
                    return result;
                }
            }
        }

        public abstract T NewModel(SqlDataReader reader);
    }
}