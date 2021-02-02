using FlowMetrics.Infra.Base;
using System;
using System.Linq;

namespace FlowMetrics.Infra.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : IEntity
    {
        void AddOrUpdate(TEntity entity);
        void Add(TEntity entity);
        void Update(TEntity entity);
        TEntity Find(Guid id);
        IQueryable<TEntity> GetAll();
        void Remove(TEntity entity);
    }
}
