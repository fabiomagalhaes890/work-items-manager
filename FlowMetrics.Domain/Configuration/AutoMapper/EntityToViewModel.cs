using AutoMapper;
using FlowMetrics.Domain.ViewModel.Assignee;
using FlowMetrics.Domain.ViewModel.Epic;
using FlowMetrics.Domain.ViewModel.Week;
using FlowMetrics.Domain.ViewModel.WorkItem;
using FlowMetrics.Work.Assignees;
using FlowMetrics.Work.Epics;
using FlowMetrics.Work.Weeks;
using FlowMetrics.Work.WorkItems;

namespace FlowMetrics.Domain.Configuration.AutoMapper
{
    public class EntityToViewModel : Profile
    {
        public EntityToViewModel()
        {
            CreateMap<WorkItem, WorkItemViewModel>();
            CreateMap<Assignee, AssigneeViewModel>();
            CreateMap<Epic, EpicViewModel>();
            CreateMap<Week, WeekViewModel>();
        }
    }
}
