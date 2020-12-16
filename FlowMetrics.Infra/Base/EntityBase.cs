using System;

namespace FlowMetrics.Infra.Base
{
    public abstract class EntityBase : IEntity, IAuditEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public void SetId(Guid id) => Id = id;
    }
}
