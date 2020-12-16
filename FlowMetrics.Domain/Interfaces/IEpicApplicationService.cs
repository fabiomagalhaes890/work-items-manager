using FlowMetrics.Domain.ViewModel.Epic;
using System.Collections.Generic;

namespace FlowMetrics.Domain.Interfaces
{
    public interface IEpicApplicationService
    {
        IEnumerable<EpicViewModel> GetAllOrderByDescending();
        void Create(EpicViewModel epic);
        IEnumerable<EpicViewModel> GetByFilter(string search);
    }
}
