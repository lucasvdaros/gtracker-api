using GTracker.Domain.Commands.Game;

namespace GTracker.Domain.Validation.Game
{
    public class UpdateGameCommandValidation : GameCommandValidation<UpdateGameCommand>
    {
        public UpdateGameCommandValidation()
        {
            ValidateName();
            ValidateAcquisitionDate();
            ValidateKind();
            ValidateObservation();
        }
    }
}