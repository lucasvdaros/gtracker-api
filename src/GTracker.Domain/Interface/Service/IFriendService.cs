using System.Collections.Generic;
using System.Threading.Tasks;
using GTracker.Domain.DTO.Friend;

namespace GTracker.Domain.Interface.Service
{
    public interface IFriendService
    {
        Task Post(CreateFriendDTO friend);
        Task<IEnumerable<FriendDTO>> GetAll();
        Task<FriendDTO> GetById(int id);
        Task Update(int id, UpdateFriendDTO friend);
    }
}