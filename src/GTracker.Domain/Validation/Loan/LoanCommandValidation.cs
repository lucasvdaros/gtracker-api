using System;
using FluentValidation;
using GTracker.Domain.Commands.Loan;

namespace GTracker.Domain.Validation.Loan
{
    public abstract class LoanCommandValidation<TCommand> : AbstractValidator<TCommand> where TCommand : LoanCommand
    {
        protected void ValidateFriend()
        {
            RuleFor(l => l.FriendId)
                .NotEmpty()
                    .WithMessage("Friend is required");
        }

        protected void ValidateDate()
        {
            RuleFor(l => l.DateStart)
                .NotEmpty()
                    .WithMessage("Date is required")
                .LessThanOrEqualTo(DateTime.Now)
                    .WithMessage("Date cannot be in the future");
        }

        protected void ValidateObservation()
        {
            RuleFor(l => l.Observation)
                .Length(0, 250)
                   .WithMessage("Observation must be a maximum of 250 characters");  
        }
    }
}