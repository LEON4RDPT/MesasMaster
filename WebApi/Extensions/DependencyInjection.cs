using Application.UseCases.JwtService;
using Application.UseCases.UserService.CreateUser;
using Application.UseCases.UserService.DeleteUser;
using Application.UseCases.UserService.GetAllUsers;
using Application.UseCases.UserService.GetUser;
using Application.UseCases.UserService.LoginUser;
using Application.UseCases.UserService.PutUser;
using Core.Interfaces;
using Infrastructure.Authentication;
using Infrastructure.Repositories;

namespace WebApi.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Handlers 
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<GetAllUsersHandler>();
            services.AddScoped<GetUserHandler>();
            services.AddScoped<PutUserHandler>();
            services.AddScoped<DeleteUserHandler>();
            services.AddScoped<LoginUserHandler>();
            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Infrastructure-layer repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;
        }
    }
}
