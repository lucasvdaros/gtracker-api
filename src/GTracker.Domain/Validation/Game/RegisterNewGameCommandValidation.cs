using GTracker.Domain.Commands.Game;

namespace GTracker.Domain.Validation.Game
{
    public class RegisterNewGameCommandValidation : GameCommandValidation<RegisterNewGameCommand>
    {
        public RegisterNewGameCommandValidation()
        {
            ValidateName();
            ValidateAcquisitionDate();
            ValidateKind();
            ValidateObservation();
        }
    }
}