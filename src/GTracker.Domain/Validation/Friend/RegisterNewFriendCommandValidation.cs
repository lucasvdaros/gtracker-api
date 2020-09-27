using GTracker.Domain.Commands.Friend;

namespace GTracker.Domain.Validation.Friend
{
    public class RegisterNewFriendCommandValidation : FriendCommandValidation<RegisterNewFriendCommand>
    {
        public RegisterNewFriendCommandValidation()
        {
            ValidateName();
            ValidatePhone();
            ValidateEmail();
        }
    }
}