using Microsoft.AspNetCore.Mvc.Infrastructure;
using PaymentGateWay.Common.Errors;

namespace PaymentGateWay.ServiceConfigurations;

public static class DependencyInjection
{
    public static IServiceCollection AddConfigurations(
        this IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddCorsConfigurations(builder.Configuration);
        services.AddSerilogConfiguration(builder);
        services.AddBraintreeService(builder.Configuration);
        services.AddSingleton<ProblemDetailsFactory,PaymentGateWayProblemDetailsFactory>();
        return services;
    }
}