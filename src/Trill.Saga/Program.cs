using System.Threading.Tasks;
using Convey.Logging;
using Convey.Secrets.Vault;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Trill.Saga
{
    class Program
    {
        public static async Task Main(string[] args)
            => await CreateHostBuilder(args)
                .Build()
                .RunAsync();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .UseLogging()
                .UseVault();
    }
}
