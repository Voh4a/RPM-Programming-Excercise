using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPM_Programming_Excercise.Common;
using RPM_Programming_Excercise.Common.DataBaseConnection;
using RPM_Programming_Excercise.EiaApi;
using RPM_Programming_Excercise.Managers.PetroleumManager;
using RPM_Programming_Excercise.Repositories.PetroleumPriceRepository;
using System;

namespace RPM_Programming_Excercise
{
    public class Startup
    {
        public IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(app =>
            {
                app.AddJsonFile("appsettings.json");
            })
            .ConfigureServices(ConfigureServices);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddHttpClient(Constants.EiaPetroleumApiName, httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.eia.gov/");
            });
            services.AddHostedService<Worker>();

            services.AddTransient<IEiaPetroleumApiService, EiaPetroleumApiService>();
            services.AddTransient<IDataBaseConnectionManager, DataBaseConnectionManager>();
            services.AddTransient<IPetroleumPriceManager, PetroleumPriceManager>();
            services.AddTransient<IPetroleumPriceRepository, PetroleumPriceRepository>();
        }
    }
}
