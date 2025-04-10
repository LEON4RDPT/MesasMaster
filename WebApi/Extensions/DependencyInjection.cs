using Application.UseCases.UserService.GetAllUsers;
using MesaApp.Application.UseCases.UserService.CreateUser;
using Core.Interfaces;
using Infrastructure.Repositories;

namespace MesaApp.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Application-layer use cases
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<GetAllUsersHandler>();
            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Infrastructure-layer repositories
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
