using FlowMetrics.Infra.Repositories;
using FlowMetrics.Work.Assignees;
using FlowMetrics.Work.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowMetrics.Infrastructure.Repositories
{
    public class AssigneeRepository : RepositoryBase<Assignee, AssigneeFilter>, IAssigneeRepository
    {
        public AssigneeRepository(DbContext context) : base(context) { }

        public override async Task<IEnumerable<Assignee>> FilterAsync(AssigneeFilter filter) => await _set.ToListAsync();
    }
}
