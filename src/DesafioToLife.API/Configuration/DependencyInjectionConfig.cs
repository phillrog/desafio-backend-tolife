using DesafioToLife.Application.Mapping;
using DesafioToLife.Application.Services;
using DesafioToLife.Domain.Intrerfaces;
using DesafioToLife.Infrastructure.Context;
using DesafioToLife.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DesafioToLife.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            // Infra
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAparelhoRepository, AparelhoRepository>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Services
            services.AddScoped<IAparelhoService, AparelhoService>();

            // AutoMapper
            services.AddAutoMapper(cfg => { cfg.AddProfile(typeof(DesafioProfile)); }, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
