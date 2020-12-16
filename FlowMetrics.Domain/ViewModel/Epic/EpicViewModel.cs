using FlowMetrics.Work.Enums;
using System;

namespace FlowMetrics.Domain.ViewModel.Epic
{
    public class EpicViewModel : ViewModelBase
    {
        public Guid? Id { get; set; }
        public string Description { get; set; }
        public string EpicId { get; set; }
        public bool? IsPrioritized { get; set; }
        public bool? ConsiderTTM { get; set; }
        public WorkStatus Status { get; set; }
    }
}
