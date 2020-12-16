using FlowMetrics.Infra.Repositories;
using FlowMetrics.Work.Repositories;
using FlowMetrics.Work.WorkToSheet;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowMetrics.Infrastructure.Repositories
{
    public class WorkSheetRepository : RepositoryBase<WorkSheet, WorkSheetFilter>, IWorkSheetRepository
    {
        public WorkSheetRepository(DbContext context) : base(context) { }

        public override async Task<IEnumerable<WorkSheet>> FilterAsync(WorkSheetFilter filter) => await _set.ToListAsync();
    }
}
