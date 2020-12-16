using FlowMetrics.Domain.ViewModel.Week;
using System.Collections.Generic;

namespace FlowMetrics.Domain.Interfaces
{
    public interface IWeekApplicationService
    {
        IEnumerable<WeekViewModel> GetAllOrderByDescending();
        void Create(WeekViewModel week);
        IEnumerable<WeekViewModel> GetByFilter(string search);
    }
}
