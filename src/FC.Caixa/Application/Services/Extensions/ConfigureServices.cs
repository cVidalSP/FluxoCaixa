using FC.Caixa.Application.Configurations;
using FC.Caixa.Domain.Interfaces.Repository;
using FC.Caixa.Domain.Interfaces.Services;
using FC.Caixa.Infrastructure.Data;
using FC.Caixa.Infrastructure.Repositories;
using FC.Caixa.Infrastructure.services;
using Microsoft.EntityFrameworkCore;

namespace FC.Caixa.Application.Services.Extensions
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