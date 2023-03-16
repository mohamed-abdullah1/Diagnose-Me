using MedicalServices.Application.Common.Interfaces.Services;
using MedicalServices.Infrastructure.Services;
using MedicalServices.Infrastructure.ServicesConfigurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalServices.Infrastructue;

public static class DependencyInjection 
{
    public static IServiceCollection AddInfrastrucure(
        this IServiceCollection services,
        ConfigurationManager configuration
        )
    {
        services.AddAuthentication(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IFileHandler, FileHandler>();
        return services;
    }
}