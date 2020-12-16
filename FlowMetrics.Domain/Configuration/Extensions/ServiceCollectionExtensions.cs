using FlowMetrics.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace FlowMetrics.Domain.Configuration.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
        {
            new InfrastructureModule().Load(serviceCollection);
            new EnvironmentModule().Load(serviceCollection);
            return serviceCollection;
        }
    }
}
