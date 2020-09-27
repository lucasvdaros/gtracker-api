using GTracker.Domain.Commands.Friend;

namespace GTracker.Domain.Validation.Friend
{
    public class UpdateFriendCommandValidation: FriendCommandValidation<UpdateFriendCommand>
    {
        public UpdateFriendCommandValidation()
        {
            ValidateName();
            ValidatePhone();
            ValidateEmail();
        }
    }
}