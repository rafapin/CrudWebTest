using CrudTestWeb.Shared.Domain.Contracts;
using CrudTestWeb.Users.Application.Config;
using CrudTestWeb.Users.Domain.Contracts;
using CrudTestWeb.Users.Infrastructure.Implementations.Encrypt;
using CrudTestWeb.Users.Infrastructure.Implementations.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrudTestWeb.Users.Infrastructure.Config
{
    public static class Config
    {
        public static IServiceCollection AddUsersInfrastructureServices(this IServiceCollection services)
        {
            string connectionString = Environment.GetEnvironmentVariable("ConnectionStringDb") ?? throw new NullReferenceException();

            services.AddDbContext<CrudTestWebContext>(options =>
            {
                options.UseSqlServer(connectionString);
            }, ServiceLifetime.Transient);
            services.AddTransient(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddSingleton(typeof(IEncryptService), typeof(Sha512EncryptService));

            return services;
        }

        public static IServiceCollection AddUsersModule(this IServiceCollection services)
        {
            services.AddUsersInfrastructureServices();
            services.AddUserApplicationServices();

            return services;
        }
    }
}
