using FC.Relatorio.Infra;
using FC.Relatorio.Infra.Settings;
using FC.Relatorio.Interfaces.Repositories;
using FC.Relatorio.Interfaces.Services;
using FC.Relatorio.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FC.Relatorio.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDBSettings>(configuration.GetSection("MongoDBSettings"));

            services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
                return new MongoClient(settings.ConnectionString);
            });

            services.AddScoped<IRelatorioService,RelatorioService>();
            services.AddScoped<IRelatorioRepository,RelatorioRepository>();

            services.AddHostedService<RabbitMQConsumer>();

            services.AddControllers();
        }
    }
}
