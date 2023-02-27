using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalServices.Persistence.ServicesConfigrations;

public static class Repositories
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
        {
            return services;
        }
}