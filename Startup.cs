using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RPM_Programming_Excercise.Common;
using RPM_Programming_Excercise.EiaApi;
using RPM_Programming_Excercise.Worker;
using System;

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
            services.AddHttpClient(Constants.EiaPetroleumApiName, httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.eia.gov/");
            });

            services.AddTransient<IEiaPetroleumApiService, EiaPetroleumApiService>();
        }
    }
}
