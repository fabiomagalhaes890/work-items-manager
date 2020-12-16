using FlowMetrics.Domain.ViewModel.Assignee;
using System.Collections.Generic;

namespace FlowMetrics.Domain.Interfaces
{
    public interface IAssigneeApplicationService
    {
        IEnumerable<AssigneeViewModel> GetAll();
        IEnumerable<string> GetAllTeams();
        IEnumerable<AssigneeViewModel> GetByFilter(string search);
        void Create(AssigneeViewModel assigneeViewModel);
    }
}
