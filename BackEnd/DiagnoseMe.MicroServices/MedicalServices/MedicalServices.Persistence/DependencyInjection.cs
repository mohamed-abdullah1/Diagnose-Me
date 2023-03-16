using MedicalServices.Persistence.ServicesConfigrations;
using MedicalServices.Persistence.ServicesConfigurations;
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
        services.AddUnitOfWork();
        services.AddDbContextConfiguration(configuration);
        return services;
    }

    

        


}