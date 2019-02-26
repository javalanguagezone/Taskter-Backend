using Microsoft.Extensions.DependencyInjection;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Repositories;
using Taskter.Infrastructure.UserContext;

namespace Taskter.Infrastructure.Shared
{
    public static class IoCRegistrationExtension
    {
        public static void RegisterIoCDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectTaskEntryRepository, ProjectTaskEntryRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddTransient<ICurrentUserContext, CurrentUserContext>();
        }
    }
}
