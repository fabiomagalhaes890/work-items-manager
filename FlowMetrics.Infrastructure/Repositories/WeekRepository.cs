using FlowMetrics.Infra.Repositories;
using FlowMetrics.Work.Repositories;
using FlowMetrics.Work.Weeks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowMetrics.Infrastructure.Repositories
{
    public class WeekRepository : RepositoryBase<Week, WeekFilter>, IWeekRepository
    {
        public WeekRepository(DbContext context) : base(context) { }

        public override async Task<IEnumerable<Week>> FilterAsync(WeekFilter filter) => await _set.ToListAsync();
    }
}
