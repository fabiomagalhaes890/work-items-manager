using FlowMetrics.Infra.Base;

namespace FlowMetrics.Work.Assignees
{
    public class Assignee : EntityBase
    {
        public Assignee(string name)
        {
            SetName(name);
        }

        public string Name { get; private set; }
        public string Team { get; private set; }
        public void SetName(string name) => Name = name;
        public void SetTeam(string team) => Team = team;
    }
}
