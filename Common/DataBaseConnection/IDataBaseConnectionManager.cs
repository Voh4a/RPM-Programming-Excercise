using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise.Common.DataBaseConnection
{
    public interface IDataBaseConnectionManager
    {
        SqlConnection GetSqlConnection();
        Task OpenSqlConnectionAsync(SqlConnection connection);
        Task CloseSqlConnectionAsync(SqlConnection connection);
    }
}
