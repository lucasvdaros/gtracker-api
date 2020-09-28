using System.Threading.Tasks;
using GTracker.Domain.DTO.Loan;

namespace GTracker.Domain.Interface.Service
{
    public interface ILoanService
    {
        Task Post(CreateLoanDTO loan);
    }
}