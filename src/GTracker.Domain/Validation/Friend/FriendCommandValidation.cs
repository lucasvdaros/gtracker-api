using FluentValidation;
using GTracker.Domain.Commands.Friend;

namespace GTracker.Domain.Validation.Friend
{
    public abstract class FriendCommandValidation<TCommand> : AbstractValidator<TCommand> where TCommand : FriendCommand
    {
        protected void ValidateName()
        {
            RuleFor(f => f.Name)
                .NotEmpty()
                    .WithMessage("Name is required")
                .Length(1, 50)
                    .WithMessage("Name must have 1 - 50 characters");
        }

        protected void ValidatePhone()
        {
            RuleFor(f => f.Phone)
                .NotEmpty()
                    .WithMessage("Phone is required")
                .Length(1, 50)
                    .WithMessage("Phone must have 1 - 50 characters");
        }

        protected void ValidateEmail()
        {
            RuleFor(f => f.Email)
                .NotEmpty()
                    .WithMessage("E-mail is required")
                .EmailAddress()
                    .WithMessage("E-mail format is invalid")
                .Length(1, 50)
                    .WithMessage("E-mail must have 1 - 50 characters");
        }
    }
}