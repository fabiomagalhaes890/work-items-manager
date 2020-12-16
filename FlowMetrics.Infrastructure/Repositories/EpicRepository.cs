using FlowMetrics.Infra.Repositories;
using FlowMetrics.Work.Epics;
using FlowMetrics.Work.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowMetrics.Infrastructure.Repositories
{
    public class EpicRepository : RepositoryBase<Epic, EpicFilter>, IEpicRepository
    {
        public EpicRepository(DbContext context) : base(context) { }

        public override async Task<IEnumerable<Epic>> FilterAsync(EpicFilter filter) => await _set.ToListAsync();
    }
}
