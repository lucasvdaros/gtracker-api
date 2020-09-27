using GTracker.Domain.Validation.Friend;

namespace GTracker.Domain.Commands.Friend
{
    public class UpdateFriendCommand : FriendCommand
    {
        public UpdateFriendCommand()
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateFriendCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}