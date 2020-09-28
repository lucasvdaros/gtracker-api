using GTracker.Domain.EntityModel;
using GTracker.Domain.Interface.Repository;

namespace GTracker.Infra.Data.Repository
{
    public class LoanRepository : BaseRepository<Loan>, ILoanRepository
    {
        public LoanRepository(GTrackerContext context) : base(context)
        {
        }
    }
}