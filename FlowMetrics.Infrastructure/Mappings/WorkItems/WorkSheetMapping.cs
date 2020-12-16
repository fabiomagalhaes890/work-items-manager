using FlowMetrics.Work.WorkToSheet;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowMetrics.Infrastructure.Mappings.WorkItems
{
    public class WorkSheetMapping : EntityBaseMapping<WorkSheet>
    {
        public override void Configure(EntityTypeBuilder<WorkSheet> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.IssueId);
            builder.Property(x => x.Week);
            builder.Property(x => x.TechDebt);
            builder.Property(x => x.Assignee);
            builder.Property(x => x.AcceptanceReleaseDate);
            builder.Property(x => x.ProductionReleaseDate);
            builder.Property(x => x.Epic);
            builder.Property(x => x.BacklogDate);
            builder.Property(x => x.ToDoDate);
            builder.Property(x => x.InProgressDate);
            builder.Property(x => x.AwaitingCodeReviewDate);
            builder.Property(x => x.ReviewingDate);
            builder.Property(x => x.AwaitingTestsDate);
            builder.Property(x => x.TestingDate);
            builder.Property(x => x.AwaitingAcceptanceTestsDate);
            builder.Property(x => x.TestingInAcceptanceDate);
            builder.Property(x => x.AwaitingProductionDate);
            builder.Property(x => x.DoneDate);
            builder.Property(x => x.Type);
            builder.Property(x => x.Status);
            builder.Property(x => x.StartImpedimentDate);
            builder.Property(x => x.EndImpedimentDate);
            builder.Property(x => x.Observations);
            builder.Property(x => x.AssigneeTeam);

            builder.HasOne(x => x.WorkItem);
            builder.Property(x => x.WorkItemId).IsRequired();
        }
    }
}