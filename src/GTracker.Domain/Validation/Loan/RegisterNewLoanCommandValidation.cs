using GTracker.Domain.Commands.Loan;

namespace GTracker.Domain.Validation.Loan
{
    public class RegisterNewLoanCommandValidation : LoanCommandValidation<RegisterNewLoanCommand>
    {
        public RegisterNewLoanCommandValidation()
        {
            ValidateFriend();
            ValidateDate();
            ValidateObservation();
        }
    }
}