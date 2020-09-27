using System.Linq;
using GTracker.Domain.EntityModel;
using GTracker.Domain.Interface.Repository;

namespace GTracker.Infra.Data.Repository
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(GTrackerContext context) : base(context)
        {
        }

        public bool IsExistGame(int id)
        {
            return dbSet.Any(g => g.Id == id);
        }
    }
}