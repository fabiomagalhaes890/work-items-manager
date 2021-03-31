using FlowMetrics.Infra.Base;
using FlowMetrics.Work.Assignees;
using FlowMetrics.Work.Enums;
using FlowMetrics.Work.Epics;
using FlowMetrics.Work.Weeks;
using System;

namespace FlowMetrics.Work.WorkItems
{
    public class WorkItem : EntityBase
    {
        public WorkItem() { }
        public WorkItem(
            string issueId,            
            bool techDebt,
            WorkStatus status,
            WorkType type,
            DateTime backlogDate)
        {
            SetIssueId(issueId);
            SetStatus(status);
            SetType(type);
            SetTechDebt(techDebt);
            SetBacklogDate(backlogDate);
        }

        public Guid WeekId { get; set; }
        public Guid EpicId { get; set; }
        public Guid? AssigneeId { get; set; }

        public string IssueId { get; private set; }
        public Week Week { get; private set; }
        public bool TechDebt { get; private set; }
        public Assignee Assignee { get; private set; }
        public string Team { get; private set; }
        public DateTime? AcceptanceReleaseDate { get; private set; }
        public DateTime? ProductionReleaseDate { get; private set; }
        public Epic Epic { get; private set; }
        public DateTime BacklogDate { get; private set; }
        public DateTime? ToDoDate { get; private set; }
        public DateTime? InProgressDate { get; private set; }
        public DateTime? AwaitingCodeReviewDate { get; private set; }
        public DateTime? ReviewingDate { get; private set; }
        public DateTime? AwaitingTestsDate { get; private set; }
        public DateTime? TestingDate { get; private set; }
        public DateTime? AwaitingAcceptanceTestsDate { get; private set; }
        public DateTime? TestingInAcceptanceDate { get; private set; }
        public DateTime? AwaitingProductionDate { get; private set; }
        public DateTime? DoneDate { get; private set; }
        public WorkType Type { get; private set; }
        public WorkStatus Status { get; private set; }
        public DateTime? StartImpedimentDate { get; private set; }
        public DateTime? EndImpedimentDate { get; private set; }
        public string Observations { get; private set; }
        public Priority? Priority { get; private set; }
        public bool? Removed { get; private set; }
        public ImpedimentKind? ImpedimentKind { get; private set; }

        public void SetIssueId(string issueId) => IssueId = issueId;
        public void SetWeek(Week week) => Week = week;
        public void SetTechDebt(bool techDebt) => TechDebt = techDebt;
        public void SetAssignee(Assignee assignee) => Assignee = assignee;
        public void SetAcceptanceReleaseDate(DateTime? dateAcceptance) => AcceptanceReleaseDate = dateAcceptance;
        public void SetProductionReleaseDate(DateTime? dateProduction) => ProductionReleaseDate = dateProduction;
        public void SetEpic(Epic epic) => Epic = epic;
        public void SetBacklogDate(DateTime includedDate) => BacklogDate = includedDate;
        public void SetToDoDate(DateTime? teamBacklogDate) => ToDoDate = teamBacklogDate;
        public void SetInProgressDate(DateTime? inprogressDate) => InProgressDate = inprogressDate;
        public void SetAwaitingCodeReviewDate(DateTime? awaitingCodeReviewDate) => AwaitingCodeReviewDate = awaitingCodeReviewDate;
        public void SetReviewingDate(DateTime? reviewingDate) => ReviewingDate = reviewingDate;
        public void SetAwaitingTestsDate(DateTime? awaitingTestsDate) => AwaitingTestsDate = awaitingTestsDate;
        public void SetTestingDate(DateTime? testingDate) => TestingDate = testingDate;
        public void SetAwaitingAcceptanceTestDate(DateTime? awaitingAcceptanceDate) => AwaitingAcceptanceTestsDate = awaitingAcceptanceDate;
        public void SetTestingInAcceptanceDate(DateTime? testingInAcceptanceDate) => TestingInAcceptanceDate = testingInAcceptanceDate;
        public void SetAwaitingProductionDate(DateTime? awaitingProductionDate) => AwaitingProductionDate = awaitingProductionDate;
        public void SetDoneDate(DateTime? doneDate) => DoneDate = doneDate;
        public void SetType(WorkType type) => Type = type;
        public void SetStatus(WorkStatus status) => Status = status;
        public void SetStartImpedimentDate(DateTime? start) => StartImpedimentDate = start;
        public void SetEndImpedimentDate(DateTime? end) => EndImpedimentDate = end;
        public void SetObservations(string obs) => Observations = obs;
        public void SetTeam(string team) => Team = team;
        public void SetPriority(Priority priority) => Priority = priority;
        public void RemoveItem() => Removed = true;
        public void RestoreItem() => Removed = false;
        public void SetImpedimentKind(ImpedimentKind? impedimentKind) => ImpedimentKind = impedimentKind;
    }
}
