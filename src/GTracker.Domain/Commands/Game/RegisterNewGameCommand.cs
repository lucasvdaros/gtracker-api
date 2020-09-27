using GTracker.Domain.Validation.Game;

namespace GTracker.Domain.Commands.Game
{
    public class RegisterNewGameCommand : GameCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewGameCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}