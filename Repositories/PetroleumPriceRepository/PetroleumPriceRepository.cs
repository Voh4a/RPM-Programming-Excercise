using Dapper;
using Microsoft.Extensions.Logging;
using RPM_Programming_Excercise.Common.DataBaseConnection;
using RPM_Programming_Excercise.Common.Repository;
using RPM_Programming_Excercise.Models;
using System;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise.Repositories.PetroleumPriceRepository
{
    public class PetroleumPriceRepository : BaseRepository, IPetroleumPriceRepository
    {
        private readonly ILogger<PetroleumPriceRepository> _logger;
        public PetroleumPriceRepository(IDataBaseConnectionManager dataBaseConnection, ILoggerFactory loggerFactory) : base(dataBaseConnection)
        {
            _logger = loggerFactory.CreateLogger<PetroleumPriceRepository>();
        }

        public async Task InsertIfNotExistsAsync(PetroleumModel model)
        {
            var query = @"IF NOT EXISTS (SELECT * FROM PetroleumPrice WHERE [Period] = @Period)
                        BEGIN
	                        INSERT INTO PetroleumPrice ([Period], Price)
	                        VALUES
	                        (@Period, @Price)
                        END";

            var parameters = new DynamicParameters();
            parameters.Add("@Period", model.Period.ToString("yyyy-MM-dd"));
            parameters.Add("@Price", model.Value);

            try
            {
                await ExecuteQueryAsync(query, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
}
    }
}
