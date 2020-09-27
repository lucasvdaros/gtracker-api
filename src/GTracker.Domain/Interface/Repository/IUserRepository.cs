using System.Threading.Tasks;
using GTracker.Domain.EntityModel;

namespace GTracker.Domain.Interface.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByLogin(string login);
    }
}