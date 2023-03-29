using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise.Common.DataBaseConnection
{
    public class DataBaseConnectionManager : IDataBaseConnectionManager
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DataBaseConnectionManager> _logger;

        public DataBaseConnectionManager(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _logger = loggerFactory.CreateLogger<DataBaseConnectionManager>();
        }

        public SqlConnection GetSqlConnection()
        {
            var connectionString = GetRPMProgrammingExcerciseDBConnectionString();

            return new SqlConnection(connectionString);
        }

        public async Task OpenSqlConnectionAsync(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    await connection.OpenAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError("Cannot connect to database");
                    _logger.LogError(ex, ex.Message);
                    throw;
                }
            }
        }

        public async Task CloseSqlConnectionAsync(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
            {
                await connection.CloseAsync();
            }
        }

        private string GetRPMProgrammingExcerciseDBConnectionString()
        {
            return _configuration.GetValue<string>(Constants.DatabaseConstants.ConnectionStringKeys.RPMProgrammingExcerciseDBConnectionStringKey);
        }
    }
}
