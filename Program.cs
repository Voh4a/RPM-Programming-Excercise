using Microsoft.Extensions.Hosting;

namespace RPM_Programming_Excercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup startup = new Startup();
            var host = startup.CreateHostBuilder(args);
            host.Build().Run();
        }
    }
}
