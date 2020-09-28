using System;
using FluentValidation;
using GTracker.Domain.Commands.Game;

namespace GTracker.Domain.Validation.Game
{
    public abstract class GameCommandValidation<TCommand> : AbstractValidator<TCommand> where TCommand : GameCommand
    {
        protected void ValidateName()
        {
            RuleFor(f => f.Name)
                .NotEmpty()
                    .WithMessage("Name is required")
                .Length(1, 50)
                    .WithMessage("Name must have 1 - 50 characters");
        }

        protected void ValidateAcquisitionDate()
        {
            RuleFor(f => f.AquisicionDate)
                .NotEmpty()
                    .WithMessage("Date is required");
        }

        protected void ValidateKind()
        {
            RuleFor(f => f.Kind)
                .NotEmpty()
                    .WithMessage("Kind is required");
        }

        protected void ValidateObservation()
        {
            RuleFor(f => f.Observation)
                .MaximumLength(250)
                    .WithMessage("Observation must be a maximum of 250 characters");    
        }
    }
}