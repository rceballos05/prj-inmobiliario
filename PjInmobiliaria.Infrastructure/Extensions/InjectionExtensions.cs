using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PjInmobiliaria.Infrastructure.Persistences.Contexts;
using PjInmobiliaria.Infrastructure.Persistences.Interfaces;
using PjInmobiliaria.Infrastructure.Persistences.Repositories;

namespace PjInmobiliaria.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            var assembly = typeof(PjInmobiliarioContext).Assembly.FullName;
            services.AddDbContext<PjInmobiliarioContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("Inmobiliaria"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWorks, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
