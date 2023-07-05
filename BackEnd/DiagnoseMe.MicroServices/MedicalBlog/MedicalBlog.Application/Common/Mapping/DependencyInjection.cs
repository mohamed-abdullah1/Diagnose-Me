using System.Reflection;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalBlog.Application.Common.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddMapping(
        this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        return services;
    }
}