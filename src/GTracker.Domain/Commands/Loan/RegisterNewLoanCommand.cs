using System.Collections.Generic;
using GTracker.Domain.Validation.Loan;

namespace GTracker.Domain.Commands.Loan
{
    public class RegisterNewLoanCommand : LoanCommand
    {   
        public IList<int> GamesId { get; set; }
      
        public RegisterNewLoanCommand()
        {
            GamesId = new List<int>();
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewLoanCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}