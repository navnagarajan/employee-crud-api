using EmployeeManagement.Common;
using EmployeeManagement.Context.Database;
using MySql.Data.MySqlClient;
using System.Data;

namespace EmployeeManagement.Repository
{
    public class DatabaseManagerImpl : IDatabaseManager
    {
        private IDbConnection? _connection;
        private readonly string _connectionString;

        public DatabaseManagerImpl()
        {
            _connectionString = FlavorConfig.ConnectionString;
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new MySqlConnection(_connectionString);
                }

                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }
    }
}
