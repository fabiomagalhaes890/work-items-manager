using FlowMetrics.Domain.ViewModel.Assignee;
using FlowMetrics.Domain.ViewModel.Epic;
using FlowMetrics.Domain.ViewModel.Week;
using FlowMetrics.Work.Enums;

namespace FlowMetrics.Domain.Filters.WorkItem
{
    public class FilterToWorkItem
    {
        public string Search { get; set; }
        public WeekViewModel Week { get; set; }
        public EpicViewModel Epic { get; set; }
        public WorkType? Type { get; set; }
        public WorkStatus? Status { get; set; }
        public AssigneeViewModel Assignee { get; set; }
        public string Team { get; set; }
        public bool? TechDebt { get; set; }
    }
}
