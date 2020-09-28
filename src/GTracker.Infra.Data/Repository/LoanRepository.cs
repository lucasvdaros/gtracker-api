using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTracker.Domain.EntityModel;
using GTracker.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace GTracker.Infra.Data.Repository
{
    public class LoanRepository : BaseRepository<Loan>, ILoanRepository
    {
        public LoanRepository(GTrackerContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Loan>> GetFiltered(int? friendId, DateTime? dtbeg, DateTime? dtend, int skip, int take)
        {
            var query = dbSet.Include(l => l.LoanGames)
                                .ThenInclude(g => g.Game)
                            .Include(f => f.Friend)
                            .AsQueryable();

            if (dtbeg != null)
            {
                query = query.Where(u => u.DateStart >= dtbeg);
            }

            if (dtend != null)
            {
                query = query.Where(u => u.DateStart <= dtend);
            }

            if (friendId != null)
            {
                query = query.Where(u => u.FriendId == friendId);
            }

            query = ApplyPagination(query, skip, take);
            var lista = await query.ToListAsync();

            foreach (var item in lista)
            {
                item.LoanGames = context.Set<LoanGame>()
                                    .Include(a => a.Game)
                                    .Where(ap => ap.LoanId == item.Id)
                                    .ToList();
            }

            return lista;
        }
    }
}