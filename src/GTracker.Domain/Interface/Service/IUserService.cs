using System.Threading.Tasks;
using GTracker.Domain.DTO.User;

namespace GTracker.Domain.Interface.Service
{
    public interface IUserService
    {
        Task<LoginResponseUserDTO> Login(LoginUserDTO login);
    }
}