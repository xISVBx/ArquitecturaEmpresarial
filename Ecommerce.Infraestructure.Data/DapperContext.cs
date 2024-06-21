using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Ecommerce.Infraestructure.Data
{
    public class DapperContext : IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public SqlConnection sqlConnection;
        public IDbTransaction transaction;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("NorthwindConnection")
                ?? throw new InvalidOperationException("Connection string 'NorthwindConnection' not found.");
            sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            transaction = sqlConnection.BeginTransaction();
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Connection?.Close();
                transaction.Connection?.Dispose();
                transaction.Dispose();
            }
        }
    }
}
