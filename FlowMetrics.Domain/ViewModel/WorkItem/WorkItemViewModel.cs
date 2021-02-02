using FlowMetrics.Domain.ViewModel.Assignee;
using FlowMetrics.Domain.ViewModel.Epic;
using FlowMetrics.Domain.ViewModel.Week;
using FlowMetrics.Work.Enums;
using System;

namespace FlowMetrics.Domain.ViewModel.WorkItem
{
    public class WorkItemViewModel : ViewModelBase
    {
        public Guid? Id { get; set; }
        public string IssueId { get; set; }
        public WeekViewModel Week { get; set; }
        public bool TechDebt { get; set; }
        public AssigneeViewModel Assignee { get; set; }
        public string Team { get; set; }
        public DateTime? AcceptanceReleaseDate { get; set; }
        public DateTime? ProductionReleaseDate { get; set; }
        public EpicViewModel Epic { get; set; }
        public DateTime BacklogDate { get; set; }
        public DateTime? ToDoDate { get; set; }
        public DateTime? InProgressDate { get; set; }
        public DateTime? AwaitingCodeReviewDate { get; set; }
        public DateTime? ReviewingDate { get; set; }
        public DateTime? AwaitingTestsDate { get; set; }
        public DateTime? TestingDate { get; set; }
        public DateTime? AwaitingAcceptanceTestsDate { get; set; }
        public DateTime? TestingInAcceptanceDate { get; set; }
        public DateTime? AwaitingProductionDate { get; set; }
        public DateTime? DoneDate { get; set; }
        public DateTime? StartImpedimentDate { get; set; }
        public DateTime? EndImpedimentDate { get; set; }
        public WorkType Type { get; set; }
        public WorkStatus Status { get; set; }
        public string Observations { get; set; }
        public DateTime? StatusDate { get; set; }
        public Priority Priority { get; set; }
    }
}