using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vinder.DAL;
using Vinder.DAL.Interfaces;
using Vinder.Services.AzureStorage.Factories;
using Vinder.Services.AzureStorage.Interfaces;
using VinderApi.Binders;
using VinderApi.Configuration;

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
            // Add framework services.
            services.AddMvc(config =>
            {
                config.ModelBinderProviders.Insert(0, new FormFileModelBinderProvider());
            });

            services.AddCors();

            services.Configure<AzureStorageSettings>(Configuration.GetSection(nameof(AzureStorageSettings)));
            services.Configure<KairosSettings>(Configuration.GetSection(nameof(KairosSettings)));

            services.AddScoped<IAzureFileHandlerFactory, AzureFileHandlerFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
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