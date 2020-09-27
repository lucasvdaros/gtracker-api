using GTracker.Domain.EntityModel;
using GTracker.Domain.Interface.Repository;

namespace GTracker.Infra.Data.Repository
{
    public class FriendRepository : BaseRepository<Friend>, IFriendRepository
    {
        public FriendRepository(GTrackerContext context) : base(context)
        {
        }
    }
}