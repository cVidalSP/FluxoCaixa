using FC.Caixa.Configurations;
using FC.Caixa.Data;
using FC.Caixa.Infra;
using FC.Caixa.Interfaces.Repository;
using FC.Caixa.Interfaces.Services;
using FC.Caixa.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FC.Caixa.Services.Extensions
{
    public static class ServiceCollectionExtensions 
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICaixaService, CaixaService>();
            services.AddScoped<ICaixaRepository, CaixaRepository>();

            services.AddSingleton<RabbitMQService>();

            services.AddControllers();
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
