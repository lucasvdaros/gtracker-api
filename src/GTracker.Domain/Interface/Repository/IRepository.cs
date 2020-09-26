using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GTracker.Domain.Interface.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> GetAll(int skip = 0, int take = 0);
        Task<TEntity> GetById(int id);
        Task Remove(int id);
        void Remove(TEntity entity);
        Task RemoveRange(IEnumerable<int> ids);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
    }
}