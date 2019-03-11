using Microsoft.Extensions.DependencyInjection;

namespace Taskter.Tests.Helpers.Factories
{
    public static class ConfigureTestServicesExtensions
    {
        public static void RegisterOptionalServices(IServiceCollection services)
        {
            // var serviceDesc = services.FirstOrDefault(desc => desc.ServiceType == typeof(ICurrentUserContext));
            // services.Remove(serviceDesc);
            // _currentUserContext = new CurrentUserContext() { UserId = 3 };
            // services.AddTransient<ICurrentUserContext>(x => _currentUserContext);
            // var sp = services.BuildServiceProvider();

        }
    }
}