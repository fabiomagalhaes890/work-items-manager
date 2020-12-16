using FlowMetrics.Infrastructure.Mappings.Assignees;
using FlowMetrics.Infrastructure.Mappings.Epics;
using FlowMetrics.Infrastructure.Mappings.Weeks;
using FlowMetrics.Infrastructure.Mappings.WorkItems;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace FlowMetrics.Infrastructure
{
    public class FlowMetricsContext : DbContext
    {
        public FlowMetricsContext() { }

        public FlowMetricsContext(DbContextOptions<FlowMetricsContext> dbContext) : base(dbContext) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=FlowMetrics;User Id=sa;Password=sa;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new WeekMapping());
            builder.ApplyConfiguration(new AssigneeMapping());
            builder.ApplyConfiguration(new EpicMapping());
            builder.ApplyConfiguration(new WorkItemMapping());
            builder.ApplyConfiguration(new WorkSheetMapping());

            base.OnModelCreating(builder);
        }
    }
}
