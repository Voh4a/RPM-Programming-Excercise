using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RPM_Programming_Excercise.Worker;
using System;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>()
            .CreateLogger<Program>();
            logger.LogInformation("Logger is working!");

            var configuration = serviceProvider.GetService<IConfigurationRoot>();
            //logger.LogInformation(configuration.GetSection("daysCount").Value);
            int exucutionDelay = int.Parse(configuration.GetSection("executionDelay").Value);

            var worker = serviceProvider.GetService<ITaskWorker>();
            while (true)
            {
                await worker.RunWorker();
                await Task.Delay(exucutionDelay);
            }
        }
    }
}
