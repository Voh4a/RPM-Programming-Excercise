using Microsoft.Extensions.Logging;
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
        public TaskWorker(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TaskWorker>();
        }

        public async Task RunWorker()
        {
            _logger.LogInformation("Worker is started");

            //1. Get information from API

            //2. Send information to manager for upserting

            _logger.LogInformation("Worker is finished");
        }
    }
}
