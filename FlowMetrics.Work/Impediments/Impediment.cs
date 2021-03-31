using FlowMetrics.Infra.Base;
using FlowMetrics.Work.Enums;
using FlowMetrics.Work.WorkItems;
using System;

namespace FlowMetrics.Work.Impediments
{
    public class Impediment : EntityBase
    {
        public Impediment(
            DateTime startDate, 
            ImpedimentKind impedimentKind, 
            string observations) 
        {
            SetStartDate(startDate);
            SetImpedimentKind(impedimentKind);
            SetObservations(observations);
        }

        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public ImpedimentKind ImpedimentKind { get; private set; }
        public string Observations { get; private set; }
        public WorkItem WorkItem { get; set; }
        public Guid? WorkItemId { get; private set; }

        public void SetStartDate(DateTime startDate) => StartDate = startDate;
        public void SetEndDate(DateTime endDate) => EndDate = endDate;
        public void SetImpedimentKind(ImpedimentKind impedimentKind) => ImpedimentKind = impedimentKind;
        public void SetObservations(string observations) => Observations = observations;
    }
}
