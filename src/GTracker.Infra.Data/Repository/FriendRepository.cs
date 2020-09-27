using System.Linq;
using GTracker.Domain.EntityModel;
using GTracker.Domain.Interface.Repository;

namespace GTracker.Infra.Data.Repository
{
    public class FriendRepository : BaseRepository<Friend>, IFriendRepository
    {
        public FriendRepository(GTrackerContext context) : base(context)
        {
        }

        public bool IsExistFriend(int id)
        {
            return dbSet.Any(f => f.Id == id);
        }
    }
}