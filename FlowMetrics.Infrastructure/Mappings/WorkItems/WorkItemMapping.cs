using FlowMetrics.Work.WorkItems;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowMetrics.Infrastructure.Mappings.WorkItems
{
    public class WorkItemMapping : EntityBaseMapping<WorkItem>
    {
        public override void Configure(EntityTypeBuilder<WorkItem> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.IssueId).IsRequired();
            builder.Property(x => x.TechDebt).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.BacklogDate).IsRequired();
            builder.Property(x => x.EpicId).IsRequired();
            builder.Property(x => x.WeekId).IsRequired();

            builder.Property(x => x.AssigneeId).IsRequired(false);
            builder.Property(x => x.AcceptanceReleaseDate).IsRequired(false);
            builder.Property(x => x.ProductionReleaseDate).IsRequired(false);
            builder.Property(x => x.ToDoDate).IsRequired(false);
            builder.Property(x => x.InProgressDate).IsRequired(false);
            builder.Property(x => x.AwaitingCodeReviewDate).IsRequired(false);
            builder.Property(x => x.ReviewingDate).IsRequired(false);
            builder.Property(x => x.AwaitingTestsDate).IsRequired(false);
            builder.Property(x => x.TestingDate).IsRequired(false);
            builder.Property(x => x.AwaitingAcceptanceTestsDate).IsRequired(false);
            builder.Property(x => x.TestingInAcceptanceDate).IsRequired(false);
            builder.Property(x => x.AwaitingProductionDate).IsRequired(false);
            builder.Property(x => x.DoneDate).IsRequired(false);
            builder.Property(x => x.StartImpedimentDate).IsRequired(false);
            builder.Property(x => x.EndImpedimentDate).IsRequired(false);
            builder.Property(x => x.Observations).IsRequired(false);
            builder.Property(x => x.Team).IsRequired(false);
            builder.Property(x => x.Priority).IsRequired(false);
            builder.Property(x => x.Removed).IsRequired(false);
            builder.Property(x => x.ImpedimentKind).IsRequired(false);

            builder.HasOne(x => x.Epic);
            builder.HasOne(x => x.Assignee);
            builder.HasOne(x => x.Week);
        }
    }
}
