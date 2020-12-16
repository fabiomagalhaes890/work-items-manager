using FlowMetrics.Work.Weeks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowMetrics.Infrastructure.Mappings.Weeks
{
    public class WeekMapping : EntityBaseMapping<Week>
    {
        public override void Configure(EntityTypeBuilder<Week> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Start).IsRequired();
            builder.Property(x => x.End).IsRequired();
            builder.Property(x => x.Sequence);
        }
    }
}
