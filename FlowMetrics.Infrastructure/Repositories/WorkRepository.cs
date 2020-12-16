using FlowMetrics.Infra.Repositories;
using FlowMetrics.Work.Repositories;
using FlowMetrics.Work.WorkItems;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowMetrics.Infrastructure.Repositories
{
    public class WorkRepository : RepositoryBase<WorkItem, WorkItemFilter>, IWorkRepository
    {
        public WorkRepository(DbContext context) : base(context) { }

        public override async Task<IEnumerable<WorkItem>> FilterAsync(WorkItemFilter filter) => await _set.ToListAsync();
    }
}
