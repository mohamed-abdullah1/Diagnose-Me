using Auth.Application.AI;
using Auth.Application.Common.Interfaces.AI;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Application.ServicesConfigrations;

public static class AIServices
{
    public static IServiceCollection AddAIServices(this IServiceCollection services)
    {
        services.AddScoped<IDoctorIdentifyService, DoctorIdentifyService>();

        return services;
    }
}