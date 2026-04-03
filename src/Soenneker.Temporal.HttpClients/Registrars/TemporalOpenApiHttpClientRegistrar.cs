using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Temporal.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Temporal.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class TemporalOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="TemporalOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddTemporalOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<ITemporalOpenApiHttpClient, TemporalOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="TemporalOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddTemporalOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<ITemporalOpenApiHttpClient, TemporalOpenApiHttpClient>();

        return services;
    }
}
