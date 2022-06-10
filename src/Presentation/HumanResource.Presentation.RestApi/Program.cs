using Microsoft.Extensions.Hosting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

namespace HumanResource.Presentation.RestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //host.MigrateDatabase();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices(service => service.AddAutofac())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseIIS();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
