using System;

namespace FlowMetrics.Domain.ViewModel.Week
{
    public class WeekViewModel : ViewModelBase
    {
        public Guid? Id { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Sequence { get; set; }
    }
}
