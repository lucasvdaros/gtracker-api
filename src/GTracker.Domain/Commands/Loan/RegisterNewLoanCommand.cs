using System.Collections.Generic;
using GTracker.Domain.Validation.Loan;

namespace GTracker.Domain.Commands.Loan
{
    public class RegisterNewLoanCommand : LoanCommand
    {
        public RegisterNewLoanCommand(IList<int> gamesId) : base(gamesId)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewLoanCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}