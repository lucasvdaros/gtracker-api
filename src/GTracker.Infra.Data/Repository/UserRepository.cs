using System.Linq;
using System.Threading.Tasks;
using GTracker.Domain.EntityModel;
using GTracker.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace GTracker.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(GTrackerContext context) : base(context)
        {
        }

        public async Task<User> GetByLogin(string login) =>
            await dbSet.Where(u => u.Login.Equals(login.Trim())).FirstOrDefaultAsync();
    }
}