using FlowMetrics.Infra.Base;
using Microsoft.EntityFrameworkCore;

namespace FlowMetrics.Infrastructure.Transactions
{
    public class Transaction : ITransaction
    {
        private readonly DbContext _context;

        public Transaction(DbContext context)
        {
            _context = context;
        }

        public void Commit() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
