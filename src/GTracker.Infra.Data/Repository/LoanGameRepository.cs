using System.Linq;
using System.Threading.Tasks;
using GTracker.Domain.EntityModel;
using GTracker.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace GTracker.Infra.Data.Repository
{
    public class LoanGameRepository : ILoanGameRepository
    {
        protected readonly GTrackerContext context;
        protected readonly DbSet<LoanGame> dbSet;

        public LoanGameRepository(GTrackerContext context)
        {   
            this.context = context;
            dbSet = context.Set<LoanGame>();
        }

        public async Task<LoanGame> getByIds(int loanId, int gameId)
        {
            return 
                await dbSet.Where(lg => lg.GameId == gameId &&
                                        lg.LoanId == loanId)
                            .FirstOrDefaultAsync();
        }

        public void Update(LoanGame loanGame) => dbSet.Update(loanGame);
    }
}