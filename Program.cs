using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace webapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration((ctx, builder) =>
            {
                var settings = builder.Build();
                string appConfigConnectionString = settings.GetConnectionString("AppConfig");

                builder.AddAzureAppConfiguration(
                    options =>
                    {
                        options.Connect(appConfigConnectionString);
                        options.Select(KeyFilter.Any);
                        options.UseFeatureFlags();
                    }
                );
            })
            .UseStartup<Startup>();
        }
    }
}
