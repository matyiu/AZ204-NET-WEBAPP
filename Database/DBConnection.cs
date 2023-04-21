using System.Data.SqlClient;

namespace webapp.DB
{
    public interface IDBConnection
    {
        SqlConnection GetConnection();
    }

    public class DBConnection : IDBConnection
    {
        private SqlConnection? _connection;

        private readonly IConfiguration _configuration;

        public DBConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
            }

            return _connection;
        }
    }
}