using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTracker.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace GTracker.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly GTrackerContext context;
        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository(GTrackerContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await dbSet.AddAsync(entity);

            return entity;
        }

        public async Task AddRange(IEnumerable<TEntity> entities) => await dbSet.AddRangeAsync(entities);

        protected virtual IQueryable<TEntity> ApplyPagination(IQueryable<TEntity> query, int skip, int take = 0)
        {
            int salto = Convert.ToInt32((skip - 1) * take);

            query = query.Skip(salto);

            if (take > 0)
                query = query.Take(take);

            return query;
        }


        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async virtual Task<TEntity> GetById(int id) => await dbSet.FindAsync(id);

        public async virtual Task<IEnumerable<TEntity>> GetAll(int skip = 0, int take = 0)
        {
            var query = dbSet.Skip(skip);

            if (take > 0)
                query = query.Take(take);

            return await query.ToListAsync();
        }

        public async Task Remove(int id) => dbSet.Remove(await dbSet.FindAsync(id));

        public void Remove(TEntity entity) => dbSet.Remove(entity);

        public async Task RemoveRange(IEnumerable<int> ids)
        {
            foreach (var id in ids)
                await Remove(id);
        }

        public void RemoveRange(IEnumerable<TEntity> entities) => dbSet.RemoveRange(entities);

        public void Update(TEntity entity) => dbSet.Update(entity);

        public void UpdateRange(IEnumerable<TEntity> entities) => dbSet.UpdateRange(entities);
    }
}