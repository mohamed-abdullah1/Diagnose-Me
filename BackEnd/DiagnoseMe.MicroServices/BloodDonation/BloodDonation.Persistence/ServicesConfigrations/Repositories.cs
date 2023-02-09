using BloodDonation.Application.Common.Interfaces.Persistence;
using BloodDonation.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonation.Persistence.ServicesConfigrations;

public static class Repositories
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
        {
            services.AddScoped<IDonationRequestRepository, DonationRequestRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
}