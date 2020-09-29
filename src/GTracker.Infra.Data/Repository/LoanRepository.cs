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

        public override async Task<Loan> GetById(int id)
        {
            var item = await dbSet.Include(f => f.Friend)
                                .Include(lg => lg.LoanGames)
                                    .ThenInclude(g => g.Game)
                                .Where(l => l.Id == id)
                                .FirstOrDefaultAsync();

            item.LoanGames = context.Set<LoanGame>()
                                    .Include(lg => lg.Game)
                                    .Where(g => g.LoanId == item.Id)
                                    .ToList();
            return item;
        }

        public async Task<IEnumerable<Loan>> GetFiltered(int? friendId, DateTime? dtbeg, DateTime? dtend, int? status, int skip, int take)
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

            if (status != null)
            {
                query = query.SelectMany(a => a.LoanGames)
                            .Where(ap => ap.LoanStatus == status)
                             .Select(ap => ap.Loan);
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