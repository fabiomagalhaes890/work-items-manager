using System;

namespace FlowMetrics.Domain.ViewModel
{
    public abstract class ViewModelBase
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
