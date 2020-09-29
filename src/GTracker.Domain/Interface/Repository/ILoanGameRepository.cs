using System.Collections.Generic;
using System.Threading.Tasks;
using GTracker.Domain.EntityModel;

namespace GTracker.Domain.Interface.Repository
{
    public interface ILoanGameRepository
    {
        Task<LoanGame> getByIds(int loanId, int gameId);
        void Update(LoanGame loanGame);
        List<int> NotAvailableGames(IList<int> gamesId);
        bool IsBorrowedGame(int id);
        bool BelongToLoan(int loanId, int gameId);
    }
}