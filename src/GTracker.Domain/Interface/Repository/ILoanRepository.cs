using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GTracker.Domain.EntityModel;

namespace GTracker.Domain.Interface.Repository
{
    public interface ILoanRepository : IRepository<Loan>
    {
        Task<IEnumerable<Loan>> GetFiltered(int? friendId, DateTime? dtbeg, DateTime? dtend, int skip, int take);
    }
}