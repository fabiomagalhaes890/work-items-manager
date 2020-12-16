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
    public class ViewModelToEntity : Profile
    {
        public ViewModelToEntity()
        {
            CreateMap<WorkItemViewModel, WorkItem>()
                .ForMember(x => x.WeekId, opt => opt.MapFrom(y => y.Week.Id))
                .ForMember(x => x.AssigneeId, opt => opt.MapFrom(y => y.Assignee.Id))
                .ForMember(x => x.EpicId, opt => opt.MapFrom(y => y.Epic.Id))
                .ForMember(x => x.Assignee, opt => opt.Ignore())
                .ForMember(x => x.Week, opt => opt.Ignore())
                .ForMember(x => x.Epic, opt => opt.Ignore());
            CreateMap<AssigneeViewModel, Assignee>();
            CreateMap<EpicViewModel, Epic>();
            CreateMap<WeekViewModel, Week>();
        }
    }
}
