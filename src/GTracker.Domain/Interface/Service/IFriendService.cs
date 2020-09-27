using System.Threading.Tasks;
using GTracker.Domain.DTO.Friend;

namespace GTracker.Domain.Interface.Service
{
    public interface IFriendService
    {
        Task Post(CreateFriendDTO friend);        
    }
}