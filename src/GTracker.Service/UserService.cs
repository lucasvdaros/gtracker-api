using System.Threading.Tasks;
using AutoMapper;
using GTracker.Domain.Commands.User;
using GTracker.Domain.Core.Interface;
using GTracker.Domain.Core.Notification;
using GTracker.Domain.DTO.User;
using GTracker.Domain.Interface.Repository;
using GTracker.Domain.Interface.Service;
using MediatR;

namespace GTracker.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _Mapper;
        private readonly IMediatorHandler _Bus;
        private readonly IPasswordService _PasswordService;
        private readonly ITokenService _TokenService;
        private readonly IUserRepository _UserRepository;
        private readonly DomainNotificationHandler _notifications;

        public UserService(IMapper mapper,
                          IMediatorHandler bus,
                          INotificationHandler<DomainNotification> notifications,
                          IUserRepository userRepository,
                          IPasswordService passwordService,
                          ITokenService tokenService)
        {
            _UserRepository = userRepository;
            _PasswordService = passwordService;
            _TokenService = tokenService;
            _Mapper = mapper;
            _Bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<LoginResponseUserDTO> Login(LoginUserDTO credentials)
        {
            var loginCommand = _Mapper.Map<LoginUserCommand>(credentials);

            if (!loginCommand.IsValid())
            {
                foreach (var error in loginCommand.ValidationResult.Errors)
                {
                    await _Bus.RaiseEvent(new DomainNotification(loginCommand.MessageType, error.ErrorMessage));
                }

                return null;
            }
            else
            {
                var user = await _UserRepository.GetByLogin(credentials.Login);

                if (user != null && Authenticate(user.Password, credentials.Password))
                {
                    return _TokenService.TokenObject(_Mapper.Map<UserDTO>(user));
                }
                else
                {
                    return new LoginResponseUserDTO
                    {
                        Authenticated = false,
                        AccessToken = null
                    };
                }
            }
        }

        public bool Authenticate(string passwordStored, string passwordInputed)
        {
            return _PasswordService.Check(passwordStored, passwordInputed).Verified;
        }
    }
}