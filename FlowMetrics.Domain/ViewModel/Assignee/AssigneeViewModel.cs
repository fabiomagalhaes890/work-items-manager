using System;

namespace FlowMetrics.Domain.ViewModel.Assignee
{
    public class AssigneeViewModel : ViewModelBase
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
    }
}
