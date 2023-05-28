using Dapper.Persistence.Repositories;
using DapperT.Application.Abstractions;
using DapperT.Persistence;
using DapperT.Persistence.Repositories;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Dapper.Persistence
{
    public static class ServiceRegistiration
    {

        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddHangfire(configuration => configuration
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage(Configuration.ConnectionString));


           services.AddHangfireServer();
        }
    }



    public static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager cfg = new ConfigurationManager();
                cfg.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/DapperAPI.API"));
                cfg.AddJsonFile("appsettings.json");

                return cfg.GetConnectionString("MicrosoftSQL");
            }
        }
    }
}
