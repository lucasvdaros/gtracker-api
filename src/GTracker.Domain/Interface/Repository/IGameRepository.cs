using GTracker.Domain.EntityModel;

namespace GTracker.Domain.Interface.Repository
{
    public interface IGameRepository : IRepository<Game>
    {
        bool IsExistGame(int id);
    }
}