using BloodDonation.Application.Common.Interfaces.Persistence;
using Microsoft.Extensions.DependencyInjection;
namespace BloodDonation.Persistence.ServicesConfigrations;


public static class UnitOfWorkConfiguration{
    public static IServiceCollection AddUnitOfWork(
        this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    
}