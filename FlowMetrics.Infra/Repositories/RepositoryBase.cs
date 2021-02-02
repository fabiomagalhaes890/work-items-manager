using FlowMetrics.Infra.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMetrics.Infra.Repositories
{
    public abstract class RepositoryBase<TEntity, TFilter> : IRepositoryBase<TEntity> where TEntity : class, IAuditEntity, IEntity
    {
        private readonly DbContext _context;
        protected DbSet<TEntity> _set { get; private set; }

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _set = context.Set<TEntity>();
        }

        public void AddOrUpdate(TEntity entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.CreatedAt = DateTime.Now;
                //entity.CreatedBy = _scopeContext.GetUserLogin();
                _set.Add(entity);
            }
            else
                Update(entity);
        }

        public void Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            //entity.CreatedBy = _scopeContext.GetUserLogin();
            _set.Add(entity);
        }

        public void Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            //entity.UpdatedBy = _scopeContext.GetUserLogin();

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }

            _set.Update(entity);
        }

        public void Remove(TEntity entity) => _set.Remove(entity);

        public TEntity Find(Guid id) => _set.Find(id);

        public IQueryable<TEntity> GetAll() => _set;

        public abstract Task<IEnumerable<TEntity>> FilterAsync(TFilter filter);
    }
}
