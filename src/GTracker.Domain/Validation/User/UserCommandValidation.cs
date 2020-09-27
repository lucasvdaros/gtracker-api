using FluentValidation;
using GTracker.Domain.Commands.User;

namespace GTracker.Domain.Validation.User
{
    public abstract class UserCommandValidation<TCommand> : AbstractValidator<TCommand> where TCommand : UserCommand
    {
        protected void ValidateLogin()
        {
            RuleFor(e => e.Login)
                .NotEmpty()
                    .WithMessage("Login is required")
                .Length(1, 50)
                    .WithMessage("Login must have 1 - 50 characters");
        }

        protected void ValidatePassword()
        {
            RuleFor(e => e.Password)
                .NotEmpty()
                    .WithMessage("Login is required");
        }
    }
}