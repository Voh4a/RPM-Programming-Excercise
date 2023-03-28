using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RPM_Programming_Excercise.Worker;

namespace RPM_Programming_Excercise
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(opt =>
            {
                opt.AddConsole();
            });
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddSingleton<ITaskWorker, TaskWorker>();
        }
    }
}
