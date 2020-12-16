using FlowMetrics.Infra.Base;
using FlowMetrics.Work.Enums;

namespace FlowMetrics.Work.Epics
{
    public class Epic : EntityBase
    {
        public Epic(string description)
        {
            SetDescription(description);
        }

        public string Description { get; private set; }
        public string EpicId { get; private set; }
        public WorkStatus Status { get; private set; }
        public bool? IsPrioritized { get; private set; }
        public bool? ConsiderTTM { get; private set; }

        public void SetDescription(string description) => Description = description;
        public void SetEpicId(string epicId) => EpicId = epicId;
        public void SetStatus(WorkStatus status) => Status = status;
        public void SetIsPrioritized(bool? isPrioritized) => IsPrioritized = isPrioritized;
        public void SetConsiderTTM(bool? considerTTM) => ConsiderTTM = considerTTM;
    }
}
