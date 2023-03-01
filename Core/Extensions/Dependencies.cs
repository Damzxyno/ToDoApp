using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Extensions;

public static class Dependencies
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(opt => opt.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}
