using FlowMetrics.Domain.Interfaces;
using FlowMetrics.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlowMetrics.Domain.Configuration
{
    public class EnvironmentModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IWorkApplicationService, WorkApplicationService>();
            serviceCollection.AddScoped<IWeekApplicationService, WeekApplicationService>();
            serviceCollection.AddScoped<IEpicApplicationService, EpicApplicationService>();
            serviceCollection.AddScoped<IAssigneeApplicationService, AssigneeApplicationService>();
        }
    }
}
