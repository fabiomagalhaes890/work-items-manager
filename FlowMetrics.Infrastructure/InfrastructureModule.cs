using FlowMetrics.Infra.Base;
using FlowMetrics.Infra.Repositories;
using FlowMetrics.Infrastructure.Repositories;
using FlowMetrics.Infrastructure.Transactions;
using FlowMetrics.Work.Assignees;
using FlowMetrics.Work.Epics;
using FlowMetrics.Work.Repositories;
using FlowMetrics.Work.Weeks;
using FlowMetrics.Work.WorkItems;
using FlowMetrics.Work.WorkToSheet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FlowMetrics.Infrastructure
{
    public class InfrastructureModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<DbContext, FlowMetricsContext>();
            serviceCollection.AddScoped<ITransaction, Transaction>();

            serviceCollection.AddScoped<IWorkRepository, WorkRepository>();
            serviceCollection.AddScoped<IRepositoryBase<WorkItem>, WorkRepository>();

            serviceCollection.AddScoped<IWeekRepository, WeekRepository>();
            serviceCollection.AddScoped<IRepositoryBase<Week>, WeekRepository>();

            serviceCollection.AddScoped<IAssigneeRepository, AssigneeRepository>();
            serviceCollection.AddScoped<IRepositoryBase<Assignee>, AssigneeRepository>();

            serviceCollection.AddScoped<IEpicRepository, EpicRepository>();
            serviceCollection.AddScoped<IRepositoryBase<Epic>, EpicRepository>();

            serviceCollection.AddScoped<IWorkSheetRepository, WorkSheetRepository>();
            serviceCollection.AddScoped<IRepositoryBase<WorkSheet>, WorkSheetRepository>();
        }
    }
}
