using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RPM_Programming_Excercise.Common;
using RPM_Programming_Excercise.EiaApi;
using RPM_Programming_Excercise.Managers.PetroleumManager;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEiaPetroleumApiService _petroleumApiService;
        private readonly IPetroleumPriceManager _petroleumPriceManager;
        private readonly IConfiguration _configuration;

        public Worker(ILoggerFactory loggerFactory, IEiaPetroleumApiService petroleumApiService, IPetroleumPriceManager petroleumPriceManager, IConfiguration configuration)
        {
            _logger = loggerFactory.CreateLogger<Worker>();
            _petroleumApiService = petroleumApiService;
            _petroleumPriceManager = petroleumPriceManager;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int exucutionDelay = _configuration.GetValue<int>(Constants.CustomValuesConfiguration.ValueKeys.ExecutionDelayKey);
            while (!stoppingToken.IsCancellationRequested)
            {
                await DoWork();
                await Task.Delay(exucutionDelay, stoppingToken);
            }
        }

        private async Task DoWork()
        {
            _logger.LogInformation("Worker is started");

            try
            {
                //1. Get information from API
                var petroleumResult = await _petroleumApiService.GetPetroleumData();

                if (petroleumResult == null || !petroleumResult.Any())
                {
                    _logger.LogInformation("Retrived data from Eia Petroleum Api is empty");
                    return;
                }

                var model = petroleumResult.First();

                //2. Send information to manager for upserting
                await _petroleumPriceManager.InsertIfNotExistsAsync(model);

                _logger.LogInformation("Worker is finished successfully");
            }
            catch
            {
                _logger.LogError("Worker is finished with errors");
            }
        }
    }
}
