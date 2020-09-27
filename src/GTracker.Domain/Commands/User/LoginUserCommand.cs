using GTracker.Domain.Validation.User;

namespace GTracker.Domain.Commands.User
{
    public class LoginUserCommand : UserCommand
    {
        public LoginUserCommand(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public override bool IsValid()
        {
            ValidationResult = new LoginUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}