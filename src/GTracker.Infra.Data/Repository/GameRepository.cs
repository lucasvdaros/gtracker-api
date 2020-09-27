using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTracker.Domain.EntityModel;
using GTracker.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace GTracker.Infra.Data.Repository
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(GTrackerContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Game>> GetFiltered(string name, DateTime? dtbeg, DateTime? dtend, int? kind, int skip, int take)
        {
            var query = dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(u => u.Name.Contains(name));
            }

            if (dtbeg != null)
            {
                query = query.Where(u => u.AquisicionDate >= dtbeg);
            }

            if (dtend != null)
            {
                query = query.Where(u => u.AquisicionDate <= dtend);
            }

            if (kind != null)
            {
                query = query.Where(u => u.Kind == kind);
            }

            query = ApplyPagination(query, skip, take);

            return await query.ToListAsync();
        }

        public bool IsExistGame(int id)
        {
            return dbSet.Any(g => g.Id == id);
        }
    }
}