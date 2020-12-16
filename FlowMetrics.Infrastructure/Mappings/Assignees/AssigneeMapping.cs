using FlowMetrics.Work.Assignees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowMetrics.Infrastructure.Mappings.Assignees
{
    public class AssigneeMapping : EntityBaseMapping<Assignee>
    {
        public override void Configure(EntityTypeBuilder<Assignee> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Team).IsRequired(false);
        }
    }
}
