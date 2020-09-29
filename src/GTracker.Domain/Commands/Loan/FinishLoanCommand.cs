using GTracker.Domain.Validation.Loan;

namespace GTracker.Domain.Commands.Loan
{
    public class FinishLoanCommand : LoanCommand
    {
        public int LoanId { get; set; }
        public int GameId { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new FinishLoanCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}