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

        public async Task<IEnumerable<Game>> GetFiltered(string name, DateTime? dtbeg, DateTime? dtend, int? kind, int? status, int skip, int take)
        {
            var query = dbSet.Include(gl => gl.LoanGames)
                        .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(u => u.Name.Contains(name));
            }

            if (dtbeg != null)
            {
                query = query.Where(u => u.AcquisicionDate >= dtbeg);
            }

            if (dtend != null)
            {
                query = query.Where(u => u.AcquisicionDate <= dtend);
            }

            if (kind != null)
            {
                query = query.Where(u => u.Kind == kind);
            }

            if (status != null)
            {
                query = query.SelectMany(a => a.LoanGames)
                            .Where(ap => ap.LoanStatus == status)
                            .Select(ap => ap.Game)
                            .Distinct()
                            .OrderBy(l => l.Id);
            }

            query = ApplyPagination(query, skip, take);

            var lista = await query.ToListAsync();

            foreach (var item in lista)
            {
                item.LoanGames = context.Set<LoanGame>()
                                    .Where(ap => ap.GameId == item.Id)
                                    .ToList();
            }

            return lista;
        }

        public async Task<IList<LoanGame>> GetLoanGamesById(IList<int> gamesId)
        {
            List<LoanGame> games = new List<LoanGame>();

            foreach (var id in gamesId)
            {
                var loanGame = new LoanGame();
                var game = await GetById(id);

                loanGame.Game = game;
                loanGame.LoanStatus = 0;
                games.Add(loanGame);
            }

            return games;
        }

        public bool IsExistGame(int id)
        {
            return dbSet.Any(g => g.Id == id);
        }

        public bool IsExistGames(IList<int> gamesId)
        {
            foreach (var id in gamesId)
            {
                if (!dbSet.Any(g => g.Id == id)) return false;
            }

            return true;
        }
    }
}