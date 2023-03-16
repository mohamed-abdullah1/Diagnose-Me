namespace MedicalServices.Application.MiddlewaresConfigurations.Middlewares;

public class IpRateLimitingExtraOptions
{
    public List<string> HostWhiteList { get; set; } = new();
}