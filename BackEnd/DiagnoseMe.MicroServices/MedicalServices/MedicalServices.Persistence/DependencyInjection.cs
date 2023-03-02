using MedicalServices.Persistence.ServicesConfigrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalServices.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        ConfigurationManager configuration
        )
    {
        services.AddRepositories();
        services.AddDbContextConfiguration(configuration);
        return services;
    }

    

        


}