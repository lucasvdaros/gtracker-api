using FluentValidation;
using GTracker.Domain.Commands.Loan;

namespace GTracker.Domain.Validation.Loan
{
    public class FinishLoanCommandValidation : LoanCommandValidation<FinishLoanCommand>
    {
        public FinishLoanCommandValidation()
        {
            ValidateGame();
        }

        private void ValidateGame()
        {
            RuleFor(l => l.GameId)
                .NotEmpty()
                    .WithMessage("Game is required");
        }
    }
}