using PaymentGateWay.Interfaces;
using PaymentGateWay.Services;

namespace PaymentGateWay.ServiceConfigurations;

public static class BraintreeServiceConfiguration
{
    public static IServiceCollection AddBraintreeService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IBraintreeService, BraintreeService>();
        return services;
    }
}