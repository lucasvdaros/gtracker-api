using GTracker.Domain.Commands.User;

namespace GTracker.Domain.Validation.User
{
    public class LoginUserCommandValidation : UserCommandValidation<LoginUserCommand>
    {
        public LoginUserCommandValidation()
        {
            ValidateLogin();
            ValidatePassword();
        }
    }
}