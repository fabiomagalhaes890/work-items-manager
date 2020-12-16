using System;

namespace FlowMetrics.Infra.Base
{
    public interface IEntity
    {
        Guid Id { get; }
        void SetId(Guid id);
    }
}
