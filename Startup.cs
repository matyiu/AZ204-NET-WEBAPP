using Microsoft.FeatureManagement;
using webapp.Services;
using webapp.DB;
using webapp.Repositories;

namespace webapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("appsettings.json", false, true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDBConnection, DBConnection>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IProductService, ProductService>();

            services.AddAzureAppConfiguration();
            services.AddAuthorization();
            services.AddRazorPages();
            services.AddFeatureManagement();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseAzureAppConfiguration();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}