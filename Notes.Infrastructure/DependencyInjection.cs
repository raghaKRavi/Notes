using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Common.Interfaces.Authentication;
using Notes.Application.Common.Interfaces.Services;
using Notes.Infrastructure.Authentication;
using Notes.Infrastructure.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}