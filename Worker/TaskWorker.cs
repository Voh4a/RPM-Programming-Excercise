using Microsoft.Extensions.Logging;
using RPM_Programming_Excercise.EiaApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise.Worker
{
    public class TaskWorker : ITaskWorker
    {
        private readonly ILogger<TaskWorker> _logger;
        private readonly IEiaPetroleumApiService _petroleumApiService;
        public TaskWorker(ILoggerFactory loggerFactory, IEiaPetroleumApiService petroleumApiService)
        {
            _logger = loggerFactory.CreateLogger<TaskWorker>();
            _petroleumApiService = petroleumApiService;
        }

        public async Task RunWorker()
        {
            _logger.LogInformation("Worker is started");

            //1. Get information from API
            await _petroleumApiService.GeteData();

            //2. Send information to manager for upserting

            _logger.LogInformation("Worker is finished");
        }
    }
}
