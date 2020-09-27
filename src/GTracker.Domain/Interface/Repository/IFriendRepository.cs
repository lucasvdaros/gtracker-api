using GTracker.Domain.EntityModel;

namespace GTracker.Domain.Interface.Repository
{
    public interface IFriendRepository : IRepository<Friend>
    {
        bool IsExistFriend(int id);
    }
}