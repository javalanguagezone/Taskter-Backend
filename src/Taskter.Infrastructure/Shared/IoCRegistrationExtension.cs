using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            services.AddScoped<IDummyRepository, DummyRepository>();

            services.AddTransient<ICurrentUserContext, CurrentUserContext>();
        }
    }
}
