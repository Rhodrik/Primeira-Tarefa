using Npgsql;
using Primeira_Tarefa.Constant;
using Primeira_Tarefa.Interfaces.Connections;
using System.Data;

namespace Primeira_Tarefa.Database
{
    public class PostgresDatabaseConnection : IPostgresConnection
    {
        private readonly NpgsqlConnection _connection;
        public PostgresDatabaseConnection(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(ConnectionString.Postgres);
            _connection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection Get() => _connection;
    }
}
