using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection));

        return services;
    }
}
