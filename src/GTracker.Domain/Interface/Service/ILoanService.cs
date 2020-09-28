using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GTracker.Domain.DTO.Loan;

namespace GTracker.Domain.Interface.Service
{
    public interface ILoanService
    {
        Task Post(CreateLoanDTO loan);
        Task<IEnumerable<LoanDTO>> GetFiltered(int? friendId, DateTime? dtbeg, DateTime? dtend, int skip, int take);
        Task<LoanDTO> GetById(int id);
    }
}