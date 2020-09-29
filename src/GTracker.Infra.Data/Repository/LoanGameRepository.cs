using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTracker.Domain.EntityModel;
using GTracker.Domain.Enum;
using GTracker.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace GTracker.Infra.Data.Repository
{
    public class LoanGameRepository : ILoanGameRepository
    {
        protected readonly GTrackerContext context;
        protected readonly DbSet<LoanGame> dbSet;
        private readonly IGameRepository _gameRepository;

        public LoanGameRepository(GTrackerContext context, IGameRepository gameRepository)
        {
            this.context = context;
            dbSet = context.Set<LoanGame>();
            _gameRepository = gameRepository;
        }

        public async Task<LoanGame> getByIds(int loanId, int gameId)
        {
            return
                await dbSet.Where(lg => lg.GameId == gameId &&
                                        lg.LoanId == loanId)
                            .FirstOrDefaultAsync();
        }

        public void Update(LoanGame loanGame) => dbSet.Update(loanGame);

        public List<int> NotAvailableGames(IList<int> gamesId)
        {
            var gamesBorrowed = new List<int>();

            foreach (var id in gamesId)
            {
                if (IsBorrowedGame(id))
                {
                    gamesBorrowed.Add(id); ;
                }
            }

            return gamesBorrowed;
        }

        public bool IsBorrowedGame(int id)
        {
            return dbSet.Any(g => g.GameId == id &&
                                g.LoanStatus == (int)StatusLoanEnum.BORROWED &&
                                g.DataEnd == null);
        }

        public bool BelongToLoan(int loanId, int gameId)
        {
            return dbSet.Any(lg => lg.LoanId == loanId && lg.GameId == gameId);
        }
    }
}