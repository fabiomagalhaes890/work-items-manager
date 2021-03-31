using FlowMetrics.Domain.ViewModel.Week;
using System.Collections.Generic;

namespace FlowMetrics.Domain.Interfaces
{
    public interface IWeekApplicationService
    {
        IEnumerable<WeekViewModel> GetAllOrderByDescending();
        void CreateOrUpdate(WeekViewModel week);
        IEnumerable<WeekViewModel> GetByFilter(string search);
    }
}
