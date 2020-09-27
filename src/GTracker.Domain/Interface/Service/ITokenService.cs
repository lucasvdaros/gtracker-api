using GTracker.Domain.DTO.User;

namespace GTracker.Domain.Interface.Service
{
    public interface ITokenService
    {
        LoginResponseUserDTO TokenObject(UserDTO user);
    }
}