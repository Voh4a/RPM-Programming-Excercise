using Dapper;
using RPM_Programming_Excercise.Common.DataBaseConnection;
using System.Data;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise.Common.Repository
{
    public abstract class BaseRepository
    {
        protected readonly IDataBaseConnectionManager _dataBaseConnection;

        protected BaseRepository(IDataBaseConnectionManager dataBaseConnection)
        {
            _dataBaseConnection = dataBaseConnection;
            
        }

        protected async Task<bool> ExecuteQueryAsync(string query, DynamicParameters parameters = null, CommandType commandType = CommandType.Text)
        {
            using var connection = _dataBaseConnection.GetSqlConnection();
            try
            {
                await _dataBaseConnection.OpenSqlConnectionAsync(connection);
                var result = await connection.ExecuteAsync(query, parameters, commandType: commandType);
                return result > 0;
            }
            finally
            {
                //IMPORTANT: Close connection manually, since "using var connection = ..." doesn't close connection in Dispose() and thus SQL server runs out-of-connection ports
                await _dataBaseConnection.CloseSqlConnectionAsync(connection);
            }
        }
    }
}
