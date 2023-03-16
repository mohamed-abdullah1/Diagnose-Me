using MedicalBlog.Application.Common.Interfaces.Persistence;
using Microsoft.Extensions.DependencyInjection;
namespace MedicalBlog.Persistence.ServicesConfigrations;


public static class UnitOfWorkConfiguration{
    public static IServiceCollection AddUnitOfWork(
        this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    
}