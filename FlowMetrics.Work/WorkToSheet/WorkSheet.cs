using FlowMetrics.Infra.Base;
using FlowMetrics.Work.WorkItems;
using System;

namespace FlowMetrics.Work.WorkToSheet
{
    public class WorkSheet : EntityBase
    {
        public string IssueId { get; set; }
        public string Week { get; set; }
        public string TechDebt { get; set; }
        public string Assignee { get; set; }
        public string AssigneeTeam { get; set; }
        public string AcceptanceReleaseDate { get; set; }
        public string ProductionReleaseDate { get; set; }
        public string Epic { get; set; }
        public string BacklogDate { get; set; }
        public string ToDoDate { get; set; }
        public string InProgressDate { get; set; }
        public string AwaitingCodeReviewDate { get; set; }
        public string ReviewingDate { get; set; }
        public string AwaitingTestsDate { get; set; }
        public string TestingDate { get; set; }
        public string AwaitingAcceptanceTestsDate { get; set; }
        public string TestingInAcceptanceDate { get; set; }
        public string AwaitingProductionDate { get; set; }
        public string DoneDate { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string StartImpedimentDate { get; set; }
        public string EndImpedimentDate { get; set; }
        public string Observations { get; set; }
        public WorkItem WorkItem { get; set; }
        public Guid WorkItemId { get; set; }
        public string Priority { get; set; }
    }
}
