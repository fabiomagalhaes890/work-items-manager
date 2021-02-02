using FlowMetrics.Domain.Filters.WorkItem;
using FlowMetrics.Domain.ViewModel.Week;
using FlowMetrics.Domain.ViewModel.WorkItem;
using System;
using System.Collections.Generic;

namespace FlowMetrics.Domain.Interfaces
{
    public interface IWorkApplicationService
    {
        IEnumerable<WorkItemViewModel> GetWorkItemsByFilter(FilterToWorkItem filter);
        WorkItemViewModel CreateOrUpdate(WorkItemViewModel workItemViewModel, DateTime? date);
        IEnumerable<WorkItemViewModel> GetStockItemsByFilter(FilterToWorkItem filter);
        void DeleteWorkItem(Guid? id);
    }
}
