using GTracker.Domain.Validation.Friend;

namespace GTracker.Domain.Commands.Friend
{
    public class RegisterNewFriendCommand : FriendCommand
    {
        public RegisterNewFriendCommand() { }

        public RegisterNewFriendCommand(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewFriendCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}