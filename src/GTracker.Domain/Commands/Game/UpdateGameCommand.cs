using GTracker.Domain.Validation.Game;

namespace GTracker.Domain.Commands.Game
{
    public class UpdateGameCommand : GameCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new UpdateGameCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}