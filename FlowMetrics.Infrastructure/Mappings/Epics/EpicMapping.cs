using FlowMetrics.Work.Epics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowMetrics.Infrastructure.Mappings.Epics
{
    public class EpicMapping : EntityBaseMapping<Epic>
    {
        public override void Configure(EntityTypeBuilder<Epic> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.EpicId).IsRequired();
            builder.Property(x => x.IsPrioritized);
            builder.Property(x => x.ConsiderTTM);
            builder.Property(x => x.Status);
        }
    }
}
