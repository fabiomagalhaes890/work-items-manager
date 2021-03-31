using FlowMetrics.Infra.Base;
using System;

namespace FlowMetrics.Work.Weeks
{
    public class Week : EntityBase
    {
        public Week(DateTime start, DateTime end, int sequence)
        {
            SetStart(start);
            SetEnd(end);
            SetDescription();
            SetSequence(sequence);
        }

        public string Description { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public int Sequence { get; private set; }

        public void SetDescription() => Description = string.Format("{0:dd/MM/yyyy} a {1:dd/MM/yyyy} - {2}", Start, End, Sequence);
        public void SetStart(DateTime start) => Start = start;
        public void SetEnd(DateTime end) => End = end;
        public void SetSequence(int sequence) => Sequence = sequence;
    }
}
