using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vinder.DAL;
using Vinder.DAL.Configuration;
using Vinder.DAL.Interfaces;
using Vinder.Services.AzureStorage.Factories;
using Vinder.Services.AzureStorage.Interfaces;
using VinderApi.Binders;
using VinderApi.Configuration;
using VinderApi.Factories;
using VinderApi.Factories.Interfaces;

namespace VinderApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
#if DEBUG
            var connection = @"Server=(localdb)\mssqllocaldb;Database=VinderDb;Trusted_Connection=True;";
#endif
#if !DEBUG
            var connection = @"Server=tcp:vinderdb.database.windows.net,1433;Initial Catalog=VinderDb;Persist Security Info=False;User ID=vinderadmin;Password=p4$$w0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
#endif
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            // Add framework services.
            services.AddMvc(config =>
            {
                config.ModelBinderProviders.Insert(0, new FormFileModelBinderProvider());
            });

            services.AddCors();

            services.Configure<AzureStorageSettings>(Configuration.GetSection(nameof(AzureStorageSettings)));
            services.Configure<KairosSettings>(Configuration.GetSection(nameof(KairosSettings)));

            services.AddScoped<IAzureFileHandlerFactory, AzureFileHandlerFactory>();
            services.AddScoped<IUserFactory, UserFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder =>
                 builder.WithOrigins("*")
                 .AllowAnyHeader()
            );

            app.UseMvc();
        }
    }
}