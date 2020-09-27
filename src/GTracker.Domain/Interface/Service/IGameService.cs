using System.Threading.Tasks;
using GTracker.Domain.DTO.Game;

namespace GTracker.Domain.Interface.Service
{
    public interface IGameService
    {
        Task Post(CreateGameDTO game);
    }
}