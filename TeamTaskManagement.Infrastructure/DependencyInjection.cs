
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TeamTaskManagement.Domain.Entities;
using TeamTaskManagement.Domain.Interfaces;
using TeamTaskManagement.Infrastructure.Data;
using TeamTaskManagement.Infrastructure.Repositories;


namespace TeamTaskManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TeamTaskDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            return services;
        }
    }

}

